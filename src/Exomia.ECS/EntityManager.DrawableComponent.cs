#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using Exomia.ECS.Systems;
using Exomia.Framework;
using Exomia.Framework.Game;

namespace Exomia.ECS
{
    public sealed partial class EntityManager : DrawableComponent
    {
        private readonly Entity[] _currentlyToChanged = new Entity[INITIAL_ARRAY_SIZE];
        private readonly Entity[] _currentlyToRemove  = new Entity[INITIAL_ARRAY_SIZE];

        /// <inheritdoc />
        public override void Update(GameTime gameTime)
        {
            int currentlyToRemoveCount;
            lock (_toRemove)
            {
                currentlyToRemoveCount = Math.Min(_toRemove.Count, INITIAL_ARRAY_SIZE);
                _toRemove.CopyTo(0, _currentlyToRemove, 0, currentlyToRemoveCount);
                _toRemove.RemoveRange(0, currentlyToRemoveCount);
            }

            // ReSharper disable once InconsistentlySynchronizedField
            for (int i = 0; i < currentlyToRemoveCount; i++)
            {
                // ReSharper disable once InconsistentlySynchronizedField
                Entity entity = _currentlyToRemove[i];
                for (int si = _entitySystemsCount - 1; si >= 0; si--)
                {
                    EntitySystemBase system = _entitySystems[si];
                    if (entity._systemFlags == 0 || (entity._systemFlags & system.SystemMask) == system.SystemMask)
                    {
                        system.Remove(entity);
                    }
                }
            }

            int currentlyToChangedCount;
            lock (_toChanged)
            {
                currentlyToChangedCount = Math.Min(_toChanged.Count, INITIAL_ARRAY_SIZE);
                _toChanged.CopyTo(0, _currentlyToChanged, 0, currentlyToChangedCount);
                _toChanged.RemoveRange(0, currentlyToChangedCount);
            }

            // ReSharper disable once InconsistentlySynchronizedField
            for (int i = 0; i < currentlyToChangedCount; i++)
            {
                // ReSharper disable once InconsistentlySynchronizedField
                Entity entity = _currentlyToChanged[i];
                for (int si = _entitySystemsCount - 1; si >= 0; si--)
                {
                    EntitySystemBase system = _entitySystems[si];
                    if (entity._systemFlags == 0 || (entity._systemFlags & system.SystemMask) == system.SystemMask)
                    {
                        system.Changed(entity);
                    }
                }
            }

            for (int i = 0; i < _entityUpdateableSystemsCount; i++)
            {
                IUpdateableSystem system = _entityUpdateableSystems[i];
                if (system.Enabled)
                {
                    system.Update(gameTime);
                }
            }
        }

        /// <inheritdoc />
        public override void Draw(GameTime gameTime)
        {
            for (int i = 0; i < _entityDrawableSystemsCount; i++)
            {
                IDrawableSystem system = _entityDrawableSystems[i];
                if (system.BeginDraw())
                {
                    system.Draw(gameTime);
                    system.EndDraw();
                }
            }
        }

        /// <inheritdoc />
        protected override void OnInitialize(IServiceRegistry registry)
        {
            for (int si = _entitySystemsCount - 1; si >= 0; si--)
            {
                _entitySystems[si].Initialize(registry);
            }
        }

        #region IDisposable Support

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            if (disposing)
            {
                for (int si = _entitySystemsCount - 1; si >= 0; si--)
                {
                    _entitySystems[si].Dispose();
                }

                _entitySystemsCount           = 0;
                _entitySystems                = null!;
                _entityUpdateableSystemsCount = 0;
                _entityUpdateableSystems      = null!;
                _entityDrawableSystemsCount   = 0;
                _entityDrawableSystems        = null!;

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
                    Array.Clear(_currentlyToChanged, 0, _currentlyToChanged.Length);
                }

                lock (_toRemove)
                {
                    _toRemove.Clear();
                    Array.Clear(_currentlyToRemove, 0, _currentlyToRemove.Length);
                }
            }
        }

        #endregion
    }
}