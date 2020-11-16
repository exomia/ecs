#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Exomia.ECS.Attributes;
using Exomia.ECS.Events;
using Exomia.ECS.Systems;
using Exomia.Framework;
using Exomia.Framework.Game;
using Activator = System.Activator;

namespace Exomia.ECS
{
    /// <summary>
    ///     Manager for entities. This class cannot be inherited.
    /// </summary>
    public sealed partial class EntityManager : DrawableComponent
    {
        internal const int INITIAL_ARRAY_SIZE = 64;

        private readonly List<Entity>                                      _currentlyToChanged;
        private readonly List<Entity>                                      _currentlyToRemove;
        private readonly Dictionary<Entity, int>                           _entityMap;
        private readonly EntityPool                                        _entityPool;
        private readonly Dictionary<string, Action<EntityManager, Entity>> _initialTemplates;
        private readonly object                                            _thisLock = new object();
        private readonly List<Entity>                                      _toChanged;
        private readonly List<Entity>                                      _toRemove;
        private readonly Dictionary<string, EntitySystemBase>              _entitySystems;
        private readonly Dictionary<Type, EntitySystemBase>                _entitySystemInterfaces;

        private Entity[]           _entities;
        private EntitySystemBase[] _entityUpdateableSystems = null!;
        private EntitySystemBase[] _entityDrawableSystems   = null!;

        private int _entitiesCount;
        private int _entityDrawableSystemsCount;
        private int _entityUpdateableSystemsCount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityManager" /> class.
        /// </summary>
        /// <param name="name">        (Optional) The name. </param>
        /// <param name="managerMask"> (Optional) The manager mask. </param>
        public EntityManager(string name = "ECS", uint managerMask = 0u)
            : base(name)
        {
            _entityPool = new EntityPool(INITIAL_ARRAY_SIZE);
            _entities   = new Entity[INITIAL_ARRAY_SIZE];
            _entityMap  = new Dictionary<Entity, int>(INITIAL_ARRAY_SIZE);

            _initialTemplates       = new Dictionary<string, Action<EntityManager, Entity>>(INITIAL_ARRAY_SIZE);
            _entitySystems          = new Dictionary<string, EntitySystemBase>(INITIAL_ARRAY_SIZE);
            _entitySystemInterfaces = new Dictionary<Type, EntitySystemBase>(INITIAL_ARRAY_SIZE);

            _toChanged = new List<Entity>(INITIAL_ARRAY_SIZE);
            _toRemove  = new List<Entity>(INITIAL_ARRAY_SIZE);

            _currentlyToChanged = new List<Entity>(INITIAL_ARRAY_SIZE);
            _currentlyToRemove  = new List<Entity>(INITIAL_ARRAY_SIZE);

            InitializeEntitySystems(managerMask);
        }

        /// <summary>
        ///     Creates a new <see cref="Entity" /> from the specified template.
        /// </summary>
        /// <param name="template">    The template. </param>
        /// <param name="initialize">  (Optional) The initialize. </param>
        /// <param name="systemFlags"> (Optional) The system flags. </param>
        /// <param name="guid">        (Optional) Unique identifier. </param>
        /// <returns>
        ///     An <see cref="Entity" />.
        /// </returns>
        public Entity Create(string template, Action<EntityManager, Entity>? initialize = null, uint systemFlags = 0u, Guid? guid = null)
        {
            lock (_initialTemplates)
            {
                if (_initialTemplates.TryGetValue(template, out Action<EntityManager, Entity> action))
                {
                    return Create(
                        (m, e) =>
                        {
                            action?.Invoke(m, e);
                            initialize?.Invoke(m, e);
                        }, systemFlags, guid);
                }
            }
            return Create(initialize);
        }

        /// <summary>
        ///     Creates a new <see cref="Entity" />.
        /// </summary>
        /// <param name="initialize">  (Optional) The initialize. </param>
        /// <param name="systemFlags"> (Optional) The system flags. </param>
        /// <param name="guid">        (Optional) Unique identifier. </param>
        /// <returns>
        ///     An <see cref="Entity" />.
        /// </returns>
        public Entity Create(Action<EntityManager, Entity>? initialize = null, uint systemFlags = 0u, Guid? guid = null)
        {
            Entity entity = _entityPool.Take(guid ?? Guid.NewGuid());
            initialize?.Invoke(this, entity);
            entity._systemFlags   = systemFlags;
            entity._isInitialized = true;

            lock (_thisLock)
            {
                EnsureCapacity();
                _entityMap.Add(_entities[_entitiesCount] = entity, _entitiesCount);
                _entitiesCount++;
            }

            lock (_toChanged)
            {
                _toChanged.Add(entity);
            }

            return entity;
        }

        /// <summary>
        ///     Destroys the given <see cref="Entity" />.
        /// </summary>
        /// <param name="entity"> [in,out] The <see cref="Entity" />. </param>
        public void Destroy(ref Entity entity)
        {
            if (_entityMap.TryGetValue(entity, out int index))
            {
                lock (_thisLock)
                {
                    _entityMap.Remove(entity);

                    _entitiesCount--;
                    _entities[index]          = _entities[_entitiesCount];
                    _entities[_entitiesCount] = null!;
                }
                lock (_toRemove)
                {
                    _toRemove.Add(entity);
                }
            }

            foreach (object component in entity.Components)
            {
                EntityComponentPool.Release((dynamic)component);
            }

            _entityPool.Release(entity);

            entity = null!;
        }

        /// <summary>
        ///     Adds a <typeparamref name="TComponent" /> to the specified <paramref name="entity" /> instance.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity"> The <see cref="Entity" />. </param>
        /// <param name="action"> (Optional) The action. </param>
        /// <returns>
        ///     An <see cref="EntityManager" />.
        /// </returns>
        public EntityManager Add<TComponent>(Entity entity, Action<TComponent>? action = null) 
            where TComponent : class
        {
            return Add(entity, true, action);
        }

        /// <summary>
        ///     Adds a <typeparamref name="TComponent" /> to the specified <paramref name="entity" /> instance.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity">     The entity. </param>
        /// <param name="usePooling"> True to use pooling. </param>
        /// <param name="action">     (Optional) The action. </param>
        /// <returns>
        ///     An <see cref="EntityManager" />.
        /// </returns>
        public EntityManager Add<TComponent>(Entity entity, bool usePooling, Action<TComponent>? action = null) 
            where TComponent : class
        {
            TComponent component = usePooling
                ? EntityComponentPool<TComponent>.Take()
                : EntityComponentPool<TComponent>.Create();

            action?.Invoke(component);
            entity.Add(component);

            if (!entity._isInitialized) { return this; }

            lock (_toChanged)
            {
                _toChanged.Add(entity);
            }

            return this;
        }

        /// <summary>
        ///     Removes a <typeparamref name="TComponent" /> from the specified <paramref name="entity" /> instance.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity"> The entity. </param>
        /// <param name="action"> (Optional) The action. </param>
        /// <returns>
        ///     An <see cref="EntityManager" />.
        /// </returns>
        public EntityManager Remove<TComponent>(Entity entity, Action<TComponent>? action = null) 
            where TComponent : class
        {
            return Remove(entity, true, action);
        }

        /// <summary>
        ///     Removes a <typeparamref name="TComponent" /> from the specified <paramref name="entity" /> instance.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity">     The entity. </param>
        /// <param name="usePooling"> True to use pooling. </param>
        /// <param name="action">     (Optional) The action. </param>
        /// <returns>
        ///     An <see cref="EntityManager" />.
        /// </returns>
        public EntityManager Remove<TComponent>(Entity entity, bool usePooling, Action<TComponent>? action = null) 
            where TComponent : class
        {
            if (entity.Get(out TComponent component))
            {
                entity.Remove<TComponent>();
                action?.Invoke(component);
                if (usePooling) { EntityComponentPool<TComponent>.Release(component); }

                if (!entity._isInitialized) { return this; }

                lock (_toChanged)
                {
                    _toChanged.Add(entity);
                }
            }
            return this;
        }

        /// <summary>
        ///     Adds a template to 'initialize' an <see cref="Entity" /> from.
        /// </summary>
        /// <param name="template">   The template. </param>
        /// <param name="initialize"> The initialize. </param>
        public void AddTemplate(string template, Action<EntityManager, Entity> initialize)
        {
            lock (_initialTemplates)
            {
                _initialTemplates.Add(template, initialize);
            }
        }

        /// <summary>
        ///     Removes the template described by template.
        /// </summary>
        /// <param name="template"> The template. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool RemoveTemplate(string template)
        {
            lock (_initialTemplates)
            {
                return _initialTemplates.Remove(template);
            }
        }

        /// <inheritdoc />
        public override void Update(GameTime gameTime)
        {
            lock (_toRemove)
            {
                _currentlyToRemove.AddRange(_toRemove);
                _toRemove.Clear();
            }

            for (int i = 0; i < _currentlyToRemove.Count; i++)
            {
                Entity entity = _currentlyToRemove[i];
                for (int si = _entityUpdateableSystemsCount - 1; si >= 0; si--)
                {
                    EntitySystemBase system = _entityUpdateableSystems[si];
                    if (entity._systemFlags == 0 || (entity._systemFlags & system.SystemMask) == system.SystemMask)
                    {
                        system.Remove(entity);
                    }
                }
                for (int si = _entityDrawableSystemsCount - 1; si >= 0; si--)
                {
                    EntitySystemBase system = _entityDrawableSystems[si];
                    if (entity._systemFlags == 0 || (entity._systemFlags & system.SystemMask) == system.SystemMask)
                    {
                        system.Remove(entity);
                    }
                }
            }

            _currentlyToRemove.Clear();

            lock (_toChanged)
            {
                _currentlyToChanged.AddRange(_toChanged);
                _toChanged.Clear();
            }

            for (int i = 0; i < _currentlyToChanged.Count; i++)
            {
                Entity entity = _currentlyToChanged[i];
                for (int si = _entityUpdateableSystemsCount - 1; si >= 0; si--)
                {
                    EntitySystemBase system = _entityUpdateableSystems[si];
                    if (entity._systemFlags == 0 || (entity._systemFlags & system.SystemMask) == system.SystemMask)
                    {
                        system.Changed(entity);
                    }
                }
                for (int si = _entityDrawableSystemsCount - 1; si >= 0; si--)
                {
                    EntitySystemBase system = _entityDrawableSystems[si];
                    if (entity._systemFlags == 0 || (entity._systemFlags & system.SystemMask) == system.SystemMask)
                    {
                        system.Changed(entity);
                    }
                }
            }

            _currentlyToChanged.Clear();

            for (int i = 0; i < _entityUpdateableSystemsCount; i++)
            {
                EntitySystemBase system = _entityUpdateableSystems[i];
                if (system.Begin())
                {
                    system.Tick(gameTime);
                    system.OnEnd();
                }
            }
        }

        /// <inheritdoc />
        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < _entityDrawableSystemsCount; i++)
            {
                EntitySystemBase system = _entityDrawableSystems[i];
                if (system.Begin())
                {
                    system.Tick(gameTime);
                    system.OnEnd();
                }
            }
        }

        /// <inheritdoc />
        protected override void OnInitialize(IServiceRegistry registry)
        {
            for (int si = _entityUpdateableSystemsCount - 1; si >= 0; si--)
            {
                _entityUpdateableSystems[si].Initialize(registry);
            }
            for (int si = _entityDrawableSystemsCount - 1; si >= 0; si--)
            {
                _entityDrawableSystems[si].Initialize(registry);
            }
        }

        #region IDisposable Support

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            if (disposing)
            {
                for (int si = _entityUpdateableSystemsCount - 1; si >= 0; si--)
                {
                    _entityUpdateableSystems[si].Dispose();
                }
                _entityUpdateableSystemsCount = 0;
                _entityUpdateableSystems      = null!;

                for (int si = _entityDrawableSystemsCount - 1; si >= 0; si--)
                {
                    _entityDrawableSystems[si].Dispose();
                }
                _entityDrawableSystemsCount = 0;
                _entityDrawableSystems      = null!;

                lock (_thisLock)
                {
                    _entitiesCount = 0;
                    _entityMap.Clear();
                    _entities = null!;
                }

                lock (_initialTemplates)
                {
                    _initialTemplates.Clear();
                }

                lock (_toChanged)
                {
                    _toChanged.Clear();
                    _currentlyToChanged.Clear();
                }

                lock (_toRemove)
                {
                    _toRemove.Clear();
                    _currentlyToRemove.Clear();
                }
            }
        }

        #endregion

        private void InitializeEntitySystems(uint managerMask)
        {
            List<EntitySystemConfiguration> entitySystemUpdateableConfigurations =
                new List<EntitySystemConfiguration>(32);
            List<EntitySystemConfiguration> entitySystemDrawableConfigurations =
                new List<EntitySystemConfiguration>(32);

            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (a.FullName.StartsWith("System")) { continue; }
                if (a.FullName.StartsWith("SharpDX")) { continue; }
                if (a.FullName.StartsWith("ms")) { continue; }

                foreach (Type t in a.GetTypes())
                {
                    if (!t.IsClass || t.IsAbstract || t.IsInterface) { continue; }

                    if (typeof(EntitySystemBase).IsAssignableFrom(t))
                    {
                        EntitySystemConfigurationAttribute attribute;
                        if ((attribute = t.GetCustomAttribute<EntitySystemConfigurationAttribute>(false)) != null)
                        {
                            if (attribute.ManagerFlags == 0 || (attribute.ManagerFlags & managerMask) == managerMask)
                            {
                                switch (attribute.EntitySystemType)
                                {
                                    case EntitySystemType.Update:
                                        entitySystemUpdateableConfigurations.Add(
                                            new EntitySystemConfiguration(t, attribute));
                                        break;
                                    case EntitySystemType.Draw:
                                        entitySystemDrawableConfigurations.Add(
                                            new EntitySystemConfiguration(t, attribute));
                                        break;
                                    default:
                                        throw new ArgumentOutOfRangeException(nameof(attribute.EntitySystemType));
                                }
                            }
                        }
                    }
                }
            }

            SortEntitySystems(ref entitySystemUpdateableConfigurations);
            SortEntitySystems(ref entitySystemDrawableConfigurations);

            _entityUpdateableSystems      = new EntitySystemBase[entitySystemUpdateableConfigurations.Count];
            _entityUpdateableSystemsCount = _entityUpdateableSystems.Length;
            for (int i = 0; i < entitySystemUpdateableConfigurations.Count; i++)
            {
                _entityUpdateableSystems[i] = (EntitySystemBase)Activator.CreateInstance(
                    entitySystemUpdateableConfigurations[i].Type, this);
                _entityUpdateableSystems[i].SystemMask =
                    entitySystemUpdateableConfigurations[i].Configuration.SystemMask;

                Type t = entitySystemUpdateableConfigurations[i].Type;
                foreach (var it in t.GetInterfaces()
                                    .Except(t.BaseType!.GetInterfaces()))
                {
                    _entitySystemInterfaces.Add(it, _entityUpdateableSystems[i]);
                }

                _entitySystems.Add(
                    entitySystemUpdateableConfigurations[i].Configuration.Name,
                    _entityUpdateableSystems[i]);
            }
#if DEBUG
            Console.WriteLine(nameof(entitySystemUpdateableConfigurations));
            Console.WriteLine(string.Join(",", entitySystemUpdateableConfigurations.Select(s => s.Configuration.Name)));
            Console.WriteLine();
#endif
            entitySystemUpdateableConfigurations.Clear();

            _entityDrawableSystems      = new EntitySystemBase[entitySystemDrawableConfigurations.Count];
            _entityDrawableSystemsCount = _entityDrawableSystems.Length;
            for (int i = 0; i < entitySystemDrawableConfigurations.Count; i++)
            {
                _entityDrawableSystems[i] = (EntitySystemBase)Activator.CreateInstance(
                    entitySystemDrawableConfigurations[i].Type, this);
                _entityDrawableSystems[i].SystemMask = entitySystemDrawableConfigurations[i].Configuration.SystemMask;

                Type t = entitySystemDrawableConfigurations[i].Type;
                foreach (var it in t.GetInterfaces()
                                    .Except(t.BaseType!.GetInterfaces()))
                {
                    _entitySystemInterfaces.Add(it, _entityDrawableSystems[i]);
                }

                _entitySystems.Add(
                    entitySystemDrawableConfigurations[i].Configuration.Name,
                    _entityDrawableSystems[i]);
            }
#if DEBUG
            Console.WriteLine(nameof(entitySystemDrawableConfigurations));
            Console.WriteLine(string.Join(",", entitySystemDrawableConfigurations.Select(s => s.Configuration.Name)));
            Console.WriteLine();
#endif
            entitySystemDrawableConfigurations.Clear();
        }

        private void EnsureCapacity()
        {
            if (_entitiesCount + 1 >= _entities.Length)
            {
                int ns = _entities.Length * 2;
                Array.Resize(ref _entities, ns);
            }
        }

        private static bool Contains(string[]? arr, string name)
        {
            if (arr == null) { return false; }
            for (int a = 0; a < arr.Length; ++a)
            {
                if (name == arr[a])
                {
                    return true;
                }
            }
            return false;
        }

        private static void Insert(IList<EntitySystemConfiguration> sorted,
                                   EntitySystemConfiguration        current,

                                   // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Local
                                   int collisionDegree = 0)
        {
            if (collisionDegree > sorted.Count + 1)
            {
                throw new OverflowException("A unresolvable collision occurred in the entity system configurations.");
            }

            int indexA = sorted.Count - 1;
            for (; indexA >= 0; indexA--)
            {
                EntitySystemConfiguration system = sorted[indexA];
                if (Contains(current.Configuration.After, system.Configuration.Name))
                {
                    indexA++;
                    break;
                }
                if (Contains(system.Configuration.Before, current.Configuration.Name))
                {
                    indexA++;
                    break;
                }
            }
            int indexB = 0;
            for (; indexB < sorted.Count; indexB++)
            {
                EntitySystemConfiguration system = sorted[indexB];
                if (Contains(current.Configuration.Before, system.Configuration.Name)) { break; }
                if (Contains(system.Configuration.After, current.Configuration.Name)) { break; }
            }
            if (indexB >= indexA) //no collision
            {
                sorted.Insert(indexB, current);
            }
            else //collision
            {
                EntitySystemConfiguration collision = sorted[indexB];
                sorted.RemoveAt(indexB);
                Insert(sorted, current, collisionDegree + 1);
                Insert(sorted, collision, collisionDegree + 1);
            }
        }

        private static void SortEntitySystems(ref List<EntitySystemConfiguration> systems)
        {
            List<EntitySystemConfiguration> sorted  = new List<EntitySystemConfiguration>(systems.Count);
            List<EntitySystemConfiguration> replace = new List<EntitySystemConfiguration>(systems.Count);

            for (int i = 0; i < systems.Count; i++)
            {
                EntitySystemConfiguration current = systems[i];
                if (!string.IsNullOrEmpty(current.Configuration.Replace))
                {
                    replace.Add(current);
                    continue;
                }

                if (sorted.Count == 0)
                {
                    sorted.Add(current);
                    continue;
                }

                Insert(sorted, current);
            }

            for (int i = 0; i < replace.Count; i++)
            {
                EntitySystemConfiguration current = replace[i];

                for (int k = 0; k < sorted.Count; k++)
                {
                    if (sorted[k].Configuration.Name == current.Configuration.Replace)
                    {
                        if (current.Configuration.After == null && current.Configuration.Before == null)
                        {
                            sorted[k] = current;
                            break;
                        }
                        sorted.RemoveAt(k);

                        if (sorted.Count == 0)
                        {
                            sorted.Add(current);
                            continue;
                        }
                        Insert(sorted, current);
                    }
                }
            }

            systems.Clear();
            systems = sorted;
        }

        private class EntitySystemConfiguration
        {
            internal readonly EntitySystemConfigurationAttribute Configuration;
            internal readonly Type                               Type;

            /// <summary>
            ///     Initializes a new instance of the <see cref="EntitySystemConfiguration" /> class.
            /// </summary>
            /// <param name="type">          The type. </param>
            /// <param name="configuration"> The configuration. </param>
            internal EntitySystemConfiguration(Type type, EntitySystemConfigurationAttribute configuration)
            {
                Type          = type;
                Configuration = configuration;
            }
        }

        #region Systems

        /// <summary>
        ///     Attempts to get an <see cref="EntitySystemBase" /> from the given name.
        /// </summary>
        /// <param name="name">   The name. </param>
        /// <param name="system"> [out] The system. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetSystem(string name, out EntitySystemBase system)
        {
            return _entitySystems.TryGetValue(name, out system);
        }

        /// <summary>
        ///     Attempts to get an <see cref="EntitySystemBase" /> from the given name.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="name">   The name. </param>
        /// <param name="system"> [out] The system cast to <typeparamref name="T" />. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetSystem<T>(string name, out T system)
        {
            if (TryGetSystem(name, out EntitySystemBase s))
            {
                system = (T)(object)s;
                return true;
            }
            system = default!;
            return false;
        }

        /// <summary>
        ///     Attempts to get an <see cref="EntitySystemBase" /> from the given name.
        /// </summary>
        /// <typeparam name="T"> any interface. </typeparam>
        /// <param name="system"> [out] The system cast to <typeparamref name="T" />. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        /// <exception cref="AmbiguousMatchException"> Thrown when the Ambiguous Match error condition occurs. </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetSystem<T>(out T system) where T : class
        {
#if DEBUG
            if (!typeof(T).IsInterface)
            {
                throw new AmbiguousMatchException(
                    "The typeof(T) is not an interface and could be ambiguous or not the expected result!");
            }
#endif
            if (_entitySystemInterfaces.TryGetValue(typeof(T), out EntitySystemBase s))
            {
                system = (T)(object)s;
                return true;
            }
            system = default!;
            return false;
        }

        #endregion
    }
}