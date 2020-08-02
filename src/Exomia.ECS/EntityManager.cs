#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Collections.Generic;
using System.Reflection;
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
    public sealed class EntityManager : DrawableComponent
    {
        /// <summary>
        ///     Initial size of the array.
        /// </summary>
        internal const int INITIAL_ARRAY_SIZE = 64;

        private readonly List<Entity>                                      _currentlyToChanged;
        private readonly List<Entity>                                      _currentlyToRemove;
        private readonly Dictionary<Entity, int>                           _entityMap;
        private readonly EntityPool                                        _entityPool;
        private readonly Dictionary<string, Action<EntityManager, Entity>> _initialTemplates;
        private readonly object                                            _thisLock = new object();
        private readonly List<Entity>                                      _toChanged;
        private readonly List<Entity>                                      _toRemove;

        private Entity[]           _entities;
        private EntitySystemBase[] _entityUpdateableSystems = null!;
        private EntitySystemBase[] _entityDrawableSystems   = null!;

        private int _entitiesCount;
        private int _entityDrawableSystemsCount;
        private int _entityUpdateableSystemsCount;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityManager" /> class.
        /// </summary>
        /// <param name="name"> (Optional) The name. </param>
        public EntityManager(string name = "ECS")
            : base(name)
        {
            _entityPool = new EntityPool(INITIAL_ARRAY_SIZE);
            _entities   = new Entity[INITIAL_ARRAY_SIZE];
            _entityMap  = new Dictionary<Entity, int>(INITIAL_ARRAY_SIZE);

            _initialTemplates = new Dictionary<string, Action<EntityManager, Entity>>(INITIAL_ARRAY_SIZE);

            _toChanged = new List<Entity>(INITIAL_ARRAY_SIZE);
            _toRemove  = new List<Entity>(INITIAL_ARRAY_SIZE);

            _currentlyToChanged = new List<Entity>(INITIAL_ARRAY_SIZE);
            _currentlyToRemove  = new List<Entity>(INITIAL_ARRAY_SIZE);

            InitializeEntitySystems();
        }

        /// <summary>
        ///     Creates a new Entity.
        /// </summary>
        /// <param name="template">   The template. </param>
        /// <param name="initialize"> (Optional) The initialize. </param>
        /// <returns>
        ///     An Entity.
        /// </returns>
        public Entity Create(string template, Action<EntityManager, Entity>? initialize = null)
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
                        });
                }
            }
            return Create(initialize);
        }

        /// <summary>
        ///     Creates a new Entity.
        /// </summary>
        /// <param name="initialize"> (Optional) The initialize. </param>
        /// <returns>
        ///     An Entity.
        /// </returns>
        public Entity Create(Action<EntityManager, Entity>? initialize = null)
        {
            Entity entity = _entityPool.Take();
            initialize?.Invoke(this, entity);
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
        ///     Destroys the given entity.
        /// </summary>
        /// <param name="entity"> [in,out] The entity. </param>
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
        ///     Adds entity.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity"> The entity. </param>
        /// <param name="action"> (Optional) The action. </param>
        /// <returns>
        ///     An EntityManager.
        /// </returns>
        public EntityManager Add<TComponent>(Entity entity, Action<TComponent>? action = null)
        {
            return Add(entity, true, action);
        }

        /// <summary>
        ///     Adds entity.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity">     The entity. </param>
        /// <param name="usePooling"> True to use pooling. </param>
        /// <param name="action">     (Optional) The action. </param>
        /// <returns>
        ///     An EntityManager.
        /// </returns>
        public EntityManager Add<TComponent>(Entity entity, bool usePooling, Action<TComponent>? action = null)
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
        ///     Removes this object.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity"> The entity. </param>
        /// <param name="action"> (Optional) The action. </param>
        /// <returns>
        ///     An EntityManager.
        /// </returns>
        public EntityManager Remove<TComponent>(Entity entity, Action<TComponent>? action = null)
        {
            return Remove(entity, true, action);
        }

        /// <summary>
        ///     Removes this object.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity">     The entity. </param>
        /// <param name="usePooling"> True to use pooling. </param>
        /// <param name="action">     (Optional) The action. </param>
        /// <returns>
        ///     An EntityManager.
        /// </returns>
        public EntityManager Remove<TComponent>(Entity entity, bool usePooling, Action<TComponent>? action = null)
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
        ///     Adds a template to 'initialize'.
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
                    _entityUpdateableSystems[si].Remove(entity);
                }
                for (int si = _entityDrawableSystemsCount - 1; si >= 0; si--)
                {
                    _entityDrawableSystems[si].Remove(entity);
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
                    _entityUpdateableSystems[si].Changed(entity);
                }
                for (int si = _entityDrawableSystemsCount - 1; si >= 0; si--)
                {
                    _entityDrawableSystems[si].Remove(entity);
                }
            }

            _currentlyToChanged.Clear();

            for (int i = 0; i < _entityUpdateableSystemsCount; i++)
            {
                EntitySystemBase system = _entityUpdateableSystems[i];
                if (system.Begin())
                {
                    system.Tick(gameTime);
                    system.End();
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
                    system.End();
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
                                   int                              collisionDegree = 0)
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

        private void InitializeEntitySystems()
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
                            switch (attribute.EntitySystemType)
                            {
                                case EntitySystemType.Update:
                                    entitySystemUpdateableConfigurations.Add(new EntitySystemConfiguration(t, attribute));
                                    break;
                                case EntitySystemType.Draw:
                                    entitySystemDrawableConfigurations.Add(new EntitySystemConfiguration(t, attribute));
                                    break;
                                default:
                                    throw new ArgumentOutOfRangeException(nameof(attribute.EntitySystemType));
                            }
                            
                        }
                    }
                }
            }
            SortEntitySystems(ref entitySystemUpdateableConfigurations);
            SortEntitySystems(ref entitySystemDrawableConfigurations);
#if DEBUG
            Console.WriteLine("entitySystemUpdateableConfigurations");
#endif
            _entityUpdateableSystems      = new EntitySystemBase[entitySystemUpdateableConfigurations.Count];
            _entityUpdateableSystemsCount = _entityUpdateableSystems.Length;
            for (int i = 0; i < entitySystemUpdateableConfigurations.Count; i++)
            {
                _entityUpdateableSystems[i] = (EntitySystemBase)Activator.CreateInstance(
                    entitySystemUpdateableConfigurations[i].Type, this);
#if DEBUG
                Console.Write(entitySystemUpdateableConfigurations[i].Configuration.Name + ", ");
#endif
            }
#if DEBUG
            Console.WriteLine();
#endif
            entitySystemUpdateableConfigurations.Clear();
#if DEBUG
            Console.WriteLine("entitySystemDrawableConfigurations");
#endif
            _entityDrawableSystems      = new EntitySystemBase[entitySystemDrawableConfigurations.Count];
            _entityDrawableSystemsCount = _entityDrawableSystems.Length;
            for (int i = 0; i < entitySystemDrawableConfigurations.Count; i++)
            {
                _entityDrawableSystems[i] = (EntitySystemBase)Activator.CreateInstance(
                    entitySystemDrawableConfigurations[i].Type, this);
#if DEBUG
                Console.Write(entitySystemDrawableConfigurations[i].Configuration.Name + ", ");
#endif
            }
#if DEBUG
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

        #region EVENT SYSTEM

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1>(string key, R<T1> callback)
        {
            RHandler<T1>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1>(string key, O<T1> callback)
        {
            OHandler<T1>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1, T2>(string key, O<T1, T2> callback)
        {
            OHandler<T1, T2>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1, T2, T3>(string key, O<T1, T2, T3> callback)
        {
            OHandler<T1, T2, T3>.Register(key, callback);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <typeparam name="T4"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Register<T1, T2, T3, T4>(string key, O<T1, T2, T3, T4> callback)
        {
            OHandler<T1, T2, T3, T4>.Register(key, callback);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1>(string key, R<T1> callback)
        {
            RHandler<T1>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1>(string key, O<T1> callback)
        {
            OHandler<T1>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1, T2>(string key, O<T1, T2> callback)
        {
            OHandler<T1, T2>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1, T2, T3>(string key, O<T1, T2, T3> callback)
        {
            OHandler<T1, T2, T3>.Unregister(key);
        }

        /// <summary>
        ///     Deregisters this object.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <typeparam name="T4"> Generic type parameter. </typeparam>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        public void Unregister<T1, T2, T3, T4>(string key, O<T1, T2, T3, T4> callback)
        {
            OHandler<T1, T2, T3, T4>.Unregister(key);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <returns>
        ///     A ref T1.
        /// </returns>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public ref T1 Get<T1>(string key)
        {
            if (!RHandler<T1>.Get(key, out R<T1> r))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            return ref r.Invoke();
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o1">  [out] The first out T1. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1>(string key, out T1 o1)
        {
            if (!OHandler<T1>.Get(key, out O<T1> o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            o.Invoke(out o1);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o1">  [out] The first out T1. </param>
        /// <param name="o2">  [out] The second out T2. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2>(string key, out T1 o1, out T2 o2)
        {
            if (!OHandler<T1, T2>.Get(key, out O<T1, T2> o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            o.Invoke(out o1, out o2);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o1">  [out] The first out T1. </param>
        /// <param name="o2">  [out] The second out T2. </param>
        /// <param name="o3">  [out] The third out T3. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2, T3>(string key, out T1 o1, out T2 o2, out T3 o3)
        {
            if (!OHandler<T1, T2, T3>.Get(key, out O<T1, T2, T3> o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            o.Invoke(out o1, out o2, out o3);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <typeparam name="T4"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o1">  [out] The first out T1. </param>
        /// <param name="o2">  [out] The second out T2. </param>
        /// <param name="o3">  [out] The third out T3. </param>
        /// <param name="o4">  [out] The fourth out T4. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2, T3, T4>(string key, out T1 o1, out T2 o2, out T3 o3, out T4 o4)
        {
            if (!OHandler<T1, T2, T3, T4>.Get(key, out O<T1, T2, T3, T4> o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
            o.Invoke(out o1, out o2, out o3, out o4);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="r">   [out] The out R&lt;T1&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1>(string key, out R<T1> r)
        {
            if (!RHandler<T1>.Get(key, out r))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out O&lt;T1,T2,T3,T4&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1>(string key, out O<T1> o)
        {
            if (!OHandler<T1>.Get(key, out o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out O&lt;T1,T2,T3,T4&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2>(string key, out O<T1, T2> o)
        {
            if (!OHandler<T1, T2>.Get(key, out o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out O&lt;T1,T2,T3,T4&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2, T3>(string key, out O<T1, T2, T3> o)
        {
            if (!OHandler<T1, T2, T3>.Get(key, out o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <typeparam name="T1"> Generic type parameter. </typeparam>
        /// <typeparam name="T2"> Generic type parameter. </typeparam>
        /// <typeparam name="T3"> Generic type parameter. </typeparam>
        /// <typeparam name="T4"> Generic type parameter. </typeparam>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out O&lt;T1,T2,T3,T4&gt; to process. </param>
        /// <exception cref="KeyNotFoundException"> Thrown when a Key Not Found error condition occurs. </exception>
        public void Get<T1, T2, T3, T4>(string key, out O<T1, T2, T3, T4> o)
        {
            if (!OHandler<T1, T2, T3, T4>.Get(key, out o))
            {
                throw new KeyNotFoundException(nameof(key));
            }
        }

        #endregion
    }
}