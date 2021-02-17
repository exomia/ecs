#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System.Collections.Generic;
using Exomia.ECS.Systems;
using Exomia.Framework;
using Exomia.Framework.Game;

namespace Exomia.ECS
{
    public sealed partial class EntityManager : DrawableComponent
    {
        private readonly List<Entity> _currentlyToChanged = new List<Entity>(INITIAL_ARRAY_SIZE);
        private readonly List<Entity> _currentlyToRemove  = new List<Entity>(INITIAL_ARRAY_SIZE);

        /// <inheritdoc />
        public override void Update(GameTime gameTime)
        {
            lock (_toRemove)
            {
                _currentlyToRemove.Clear();
                _currentlyToRemove.AddRange(_toRemove);
                _toRemove.Clear();
            }

            // ReSharper disable once InconsistentlySynchronizedField
            for (int i = 0; i < _currentlyToRemove.Count; i++)
            {
                // ReSharper disable once InconsistentlySynchronizedField
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

            lock (_toChanged)
            {
                _currentlyToChanged.Clear();
                _currentlyToChanged.AddRange(_toChanged);
                _toChanged.Clear();
            }

            // ReSharper disable once InconsistentlySynchronizedField
            for (int i = 0; i < _currentlyToChanged.Count; i++)
            {
                // ReSharper disable once InconsistentlySynchronizedField
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
    }
}