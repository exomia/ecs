#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Collections.Generic;
using Exomia.Framework;
using Exomia.Framework.Game;

namespace Exomia.ECS.Systems
{
    /// <summary>
    ///     An entity system base.
    /// </summary>
    public abstract class EntitySystemBase : IDisposable
    {
        internal uint SystemFlags;
        
        /// <summary>
        ///     The entity map.
        /// </summary>
        protected readonly Dictionary<Entity, int> _entityMap;

        /// <summary>
        ///     The manager.
        /// </summary>
        protected readonly EntityManager _manager;

        /// <summary>
        ///     this lock.
        /// </summary>
        protected readonly object _thisLock = new object();

        /// <summary>
        ///     True to enable, false to disable.
        /// </summary>
        protected bool _enabled = true;

        /// <summary>
        ///     The entities.
        /// </summary>
        protected Entity[] _entities;

        /// <summary>
        ///     Number of entities.
        /// </summary>
        protected int _entitiesCount;

        /// <summary>
        ///     True if this object is initialized.
        /// </summary>
        protected bool _isInitialized;

        /// <summary>
        ///     Gets or sets a value indicating whether this object is enabled.
        /// </summary>
        /// <value>
        ///     True if enabled, false if not.
        /// </value>
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBase" /> class.
        /// </summary>
        /// <param name="manager"> The manager. </param>
        /// <exception cref="ArgumentNullException"> Thrown when one or more required arguments are null. </exception>
        protected EntitySystemBase(EntityManager manager)
        {
            _manager   = manager ?? throw new ArgumentNullException(nameof(manager));
            _entities  = new Entity[EntityManager.INITIAL_ARRAY_SIZE];
            _entityMap = new Dictionary<Entity, int>(EntityManager.INITIAL_ARRAY_SIZE);
        }

        /// <summary>
        ///     called before <see cref="Tick(Exomia.Framework.Game.GameTime)" />.
        /// </summary>
        /// <returns>
        ///     True if it should call <see cref="Tick(Exomia.Framework.Game.GameTime)" />; false otherwise.
        /// </returns>
        public virtual bool Begin()
        {
            return _isInitialized && _enabled;
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        public virtual void Tick(GameTime gameTime)
        {
            for (int i = _entitiesCount - 1; i >= 0; i--)
            {
                Tick(gameTime, _entities[i], i);
            }
        }

        /// <summary>
        ///     called after <see cref="Tick(Exomia.Framework.Game.GameTime)" />.
        /// </summary>
        public virtual void End() { }

        /// <summary>
        ///     Executes the initialize action.
        /// </summary>
        /// <param name="registry"> The registry. </param>
        protected virtual void OnInitialize(IServiceRegistry registry) { }

        /// <summary>
        ///     Grows.
        /// </summary>
        /// <param name="size"> The size. </param>
        protected abstract void Grow(int size);

        /// <summary>
        ///     Adds entity.
        /// </summary>
        /// <param name="entity"> The entity to remove. </param>
        /// <param name="index">  Zero-based index of the. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        protected abstract bool Add(Entity entity, int index);

        /// <summary>
        ///     Removes the given entity.
        /// </summary>
        /// <param name="index"> Zero-based index of the. </param>
        /// <param name="swap">  The swap. </param>
        protected abstract void Remove(int index, int swap);

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="e">        The Entity to process. </param>
        /// <param name="index">    Zero-based index of the. </param>
        protected abstract void Tick(GameTime gameTime, Entity e, int index);

        /// <summary>
        ///     Initializes this object.
        /// </summary>
        /// <param name="registry"> The registry. </param>
        internal void Initialize(IServiceRegistry registry)
        {
            if (!_isInitialized)
            {
                OnInitialize(registry);
                _isInitialized = true;
            }
        }

        internal void Changed(Entity entity)
        {
            lock (_thisLock)
            {
                if (_entityMap.TryGetValue(entity, out int index))
                {
                    if (!Add(entity, index))
                    {
                        _entitiesCount--;
                        _entities[index]          = _entities[_entitiesCount];
                        _entities[_entitiesCount] = null!;
                        _entityMap.Remove(entity);

                        Remove(index, _entitiesCount);
                    }
                }
                else
                {
                    EnsureCapacity();
                    if (Add(entity, _entitiesCount))
                    {
                        _entityMap.Add(_entities[_entitiesCount] = entity, _entitiesCount);
                        _entitiesCount++;
                    }
                }
            }
        }

        internal void Remove(Entity entity)
        {
            lock (_thisLock)
            {
                if (_entityMap.TryGetValue(entity, out int index))
                {
                    _entitiesCount--;
                    _entities[index]          = _entities[_entitiesCount];
                    _entities[_entitiesCount] = null!;
                    _entityMap.Remove(entity);

                    Remove(index, _entitiesCount);
                }
            }
        }

        private void EnsureCapacity()
        {
            if (_entitiesCount + 1 >= _entities.Length)
            {
                int ns = _entities.Length * 2;
                Array.Resize(ref _entities, ns);

                Grow(ns);
            }
        }

        #region IDisposable Support

        /// <summary>
        ///     True if disposed.
        /// </summary>
        protected bool _disposed;

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                OnDispose(disposing);
                if (disposing)
                {
                    lock (_thisLock)
                    {
                        _entitiesCount = 0;
                        _entityMap.Clear();
                        _entities = null!;
                    }
                }
                _disposed = true;
            }
        }

        /// <summary>
        ///     Release all the unmanaged resources used by the Exomia.ECS.Systems.EntitySystemBase and
        ///     optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"> True to disposing. </param>
        protected virtual void OnDispose(bool disposing) { }

        #endregion
    }
}