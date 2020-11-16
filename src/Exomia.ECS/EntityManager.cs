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
using Exomia.ECS.Attributes;
using Exomia.ECS.Systems;

namespace Exomia.ECS
{
    /// <summary>
    ///     Manager for entities. This class cannot be inherited.
    /// </summary>
    public sealed partial class EntityManager
    {
        internal const int INITIAL_ARRAY_SIZE = 64;

        private readonly object                                            _thisLock = new object();
        private readonly Dictionary<Entity, int>                           _entityMap;
        private readonly EntityPool                                        _entityPool;
        private readonly Dictionary<string, Action<EntityManager, Entity>> _initialTemplates;
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

            InitializeEntitySystems(managerMask);
        }

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
    }
}