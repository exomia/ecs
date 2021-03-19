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
        private readonly Dictionary<string, EntitySystemBase>              _entitySystemsMap;
        private readonly Dictionary<Type, EntitySystemBase>                _entitySystemInterfaces;

        private Entity[]            _entities;
        private EntitySystemBase[]  _entitySystems = null!;
        private IUpdateableSystem[] _entityUpdateableSystems = null!;
        private IDrawableSystem[]   _entityDrawableSystems   = null!;

        private int _entitiesCount;
        private int _entitySystemsCount;
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
            _entitySystemsMap          = new Dictionary<string, EntitySystemBase>(INITIAL_ARRAY_SIZE);
            _entitySystemInterfaces = new Dictionary<Type, EntitySystemBase>(INITIAL_ARRAY_SIZE);

            _toChanged = new List<Entity>(INITIAL_ARRAY_SIZE);
            _toRemove  = new List<Entity>(INITIAL_ARRAY_SIZE);

            InitializeEntitySystems(managerMask);
        }

        private void InitializeEntitySystems(uint managerMask)
        {
            List<EntitySystemConfiguration> updateableConfigurations =
                new List<EntitySystemConfiguration>(32);
            List<EntitySystemConfiguration> drawableConfigurations =
                new List<EntitySystemConfiguration>(32);

            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (a.FullName.StartsWith("System")) { continue; }
                if (a.FullName.StartsWith("ms")) { continue; }

                foreach (Type t in a.GetTypes())
                {
                    if (!t.IsClass || t.IsAbstract || t.IsInterface) { continue; }

                    if (typeof(EntitySystemBase).IsAssignableFrom(t))
                    {
                        EntitySystemConfigurationAttribute attribute;
                        if ((attribute = t.GetCustomAttribute<EntitySystemConfigurationAttribute>(false)) != null)
                        {
                            if (attribute.ManagerFlags == 0 || (managerMask & attribute.ManagerFlags) == attribute.ManagerFlags)
                            {
                                EntitySystemBase entitySystemBase = (EntitySystemBase)Activator.CreateInstance(t, this);
                                entitySystemBase.SystemMask = attribute.SystemMask;
                                _entitySystemsMap.Add(attribute.Name, entitySystemBase);

                                foreach (var it in t.GetInterfaces())
                                {
                                    if (it == typeof(IUpdateableSystem))
                                    {
                                        updateableConfigurations.Add(new EntitySystemConfiguration(attribute, entitySystemBase));
                                    }

                                    if (it == typeof(IDrawableSystem))
                                    {
                                        drawableConfigurations.Add(new EntitySystemConfiguration(attribute, entitySystemBase));
                                    }

                                    if(it == typeof(IDisposable)) { continue; }

                                    if (it != typeof(IUpdateableSystem) || it != typeof(IDrawableSystem))
                                    {
                                        _entitySystemInterfaces.Add(it, entitySystemBase);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            _entitySystems = updateableConfigurations.Concat(drawableConfigurations).Select(c => c.EntitySystemBase).ToArray();

            SortEntitySystems(ref updateableConfigurations);
            // ReSharper disable once SuspiciousTypeConversion.Global
            _entityUpdateableSystems      = updateableConfigurations.Select( c => (IUpdateableSystem)c.EntitySystemBase).ToArray();
            _entityUpdateableSystemsCount = _entityUpdateableSystems.Length;
            updateableConfigurations.Clear();

            SortEntitySystems(ref drawableConfigurations);
            // ReSharper disable once SuspiciousTypeConversion.Global
            _entityDrawableSystems      = drawableConfigurations.Select(c => (IDrawableSystem)c.EntitySystemBase).ToArray();
            _entityDrawableSystemsCount = _entityDrawableSystems.Length;
            drawableConfigurations.Clear();

            _entitySystemsCount = _entityUpdateableSystemsCount + _entityDrawableSystemsCount;
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
            // ReSharper disable once HeapView.ClosureAllocation
            return arr.Any(t => name == t);
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
                if (Contains(current.Attribute.After, system.Attribute.Name))
                {
                    indexA++;
                    break;
                }
                if (Contains(system.Attribute.Before, current.Attribute.Name))
                {
                    indexA++;
                    break;
                }
            }
            int indexB = 0;
            for (; indexB < sorted.Count; indexB++)
            {
                EntitySystemConfiguration system = sorted[indexB];
                if (Contains(current.Attribute.Before, system.Attribute.Name)) { break; }
                if (Contains(system.Attribute.After,   current.Attribute.Name)) { break; }
            }
            if (indexB >= indexA) //no collision
            {
                sorted.Insert(indexB, current);
            }
            else //collision
            {
                EntitySystemConfiguration collision = sorted[indexB];
                sorted.RemoveAt(indexB);
                Insert(sorted, current,   collisionDegree + 1);
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
                if (!string.IsNullOrEmpty(current.Attribute.Replace))
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
                    if (sorted[k].Attribute.Name == current.Attribute.Replace)
                    {
                        if (current.Attribute.After == null && current.Attribute.Before == null)
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
            internal readonly EntitySystemConfigurationAttribute Attribute;
            internal readonly EntitySystemBase                   EntitySystemBase;

            internal EntitySystemConfiguration(EntitySystemConfigurationAttribute attribute, EntitySystemBase entitySystemBase)
            {
                Attribute             = attribute;
                EntitySystemBase = entitySystemBase;
            }
        }
    }
}