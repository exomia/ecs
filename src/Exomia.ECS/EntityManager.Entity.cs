#region License

// Copyright (c) 2018-2021, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;

namespace Exomia.ECS
{
    /// <content> Manager for entities. This class cannot be inherited. </content>
    public sealed partial class EntityManager
    {
        /// <summary> Creates a new <see cref="Entity" /> from the specified template. </summary>
        /// <param name="template">    The template. </param>
        /// <param name="initialize">  (Optional) The initialize. </param>
        /// <param name="systemFlags"> (Optional) The system flags. </param>
        /// <param name="guid">        (Optional) Unique identifier. </param>
        /// <returns> An <see cref="Entity" />. </returns>
        public Entity Create(string                         template,
                             Action<EntityManager, Entity>? initialize  = null,
                             uint                           systemFlags = 0u,
                             Guid?                          guid        = null)
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

        /// <summary> Creates a new <see cref="Entity" />. </summary>
        /// <param name="initialize">  (Optional) The initialize. </param>
        /// <param name="systemFlags"> (Optional) The system flags. </param>
        /// <param name="guid">        (Optional) Unique identifier. </param>
        /// <returns> An <see cref="Entity" />. </returns>
        public Entity Create(Action<EntityManager, Entity>? initialize = null, uint systemFlags = 0u, Guid? guid = null)
        {
            Entity entity = _entityPool.Take(guid ?? Guid.NewGuid());
            initialize?.Invoke(this, entity);
            entity.SystemFlags   = systemFlags;
            entity.IsInitialized = true;

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

        /// <summary> Destroys the given <see cref="Entity" />. </summary>
        /// <param name="entity"> [in,out] The <see cref="Entity" />. </param>
        public void Destroy(ref Entity entity)
        {
            // ReSharper disable once InconsistentlySynchronizedField
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

        /// <summary> Adds a <typeparamref name="TComponent" /> to the specified <paramref name="entity" /> instance. </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity"> The <see cref="Entity" />. </param>
        /// <param name="action"> (Optional) The action. </param>
        /// <returns> An <see cref="EntityManager" />. </returns>
        public EntityManager Add<TComponent>(Entity entity, Action<TComponent>? action = null)
            where TComponent : class
        {
            return Add(entity, true, action);
        }

        /// <summary> Adds a <typeparamref name="TComponent" /> to the specified <paramref name="entity" /> instance. </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity">     The entity. </param>
        /// <param name="usePooling"> True to use pooling. </param>
        /// <param name="action">     (Optional) The action. </param>
        /// <returns> An <see cref="EntityManager" />. </returns>
        public EntityManager Add<TComponent>(Entity entity, bool usePooling, Action<TComponent>? action = null)
            where TComponent : class
        {
            TComponent component = usePooling
                ? EntityComponentPool<TComponent>.Take()
                : EntityComponentPool<TComponent>.Create();

            action?.Invoke(component);
            entity.Add(component);

            if (!entity.IsInitialized) { return this; }

            lock (_toChanged)
            {
                _toChanged.Add(entity);
            }

            return this;
        }

        /// <summary> Removes a <typeparamref name="TComponent" /> from the specified <paramref name="entity" /> instance. </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity"> The entity. </param>
        /// <param name="action"> (Optional) The action. </param>
        /// <returns> An <see cref="EntityManager" />. </returns>
        public EntityManager Remove<TComponent>(Entity entity, Action<TComponent>? action = null)
            where TComponent : class
        {
            return Remove(entity, true, action);
        }

        /// <summary> Removes a <typeparamref name="TComponent" /> from the specified <paramref name="entity" /> instance. </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="entity">     The entity. </param>
        /// <param name="usePooling"> True to use pooling. </param>
        /// <param name="action">     (Optional) The action. </param>
        /// <returns> An <see cref="EntityManager" />. </returns>
        public EntityManager Remove<TComponent>(Entity entity, bool usePooling, Action<TComponent>? action = null)
            where TComponent : class
        {
            if (entity.Get(out TComponent component))
            {
                entity.Remove<TComponent>();
                action?.Invoke(component);
                if (usePooling) { EntityComponentPool<TComponent>.Release(component); }

                if (!entity.IsInitialized) { return this; }

                lock (_toChanged)
                {
                    _toChanged.Add(entity);
                }
            }
            return this;
        }
    }
}