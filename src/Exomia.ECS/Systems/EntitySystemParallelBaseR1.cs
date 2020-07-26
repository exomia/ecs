#region License

// Copyright (c) 2018-2019, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using Exomia.Framework.Game;

namespace Exomia.ECS.Systems
{
    /// <summary>
    ///     An entity system parallel base r 1.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    public abstract class EntitySystemParallelBaseR1<TComponent1> : EntitySystemParallelBase
        where TComponent1 : IEntityComponent
    {
        /// <summary>
        ///     The first components.
        /// </summary>
        protected TComponent1[] _components1;

        /// <inheritdoc />
        protected EntitySystemParallelBaseR1(EntityManager manager, int maxDegreeOfParallelism = 2)
            : base(manager, maxDegreeOfParallelism)
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return entity.Get(out _components1[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap]  = default!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
        }

        /// <inheritdoc />
        protected override void UpdateOrDraw(GameTime gameTime, Entity entity, int index)
        {
            UpdateOrDraw(gameTime, entity, _components1[index]);
        }

        /// <inheritdoc cref="UpdateOrDraw(GameTime, Entity, int)" />
        protected abstract void UpdateOrDraw(GameTime gameTime, Entity entity, TComponent1 c1);

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
        }
    }
}