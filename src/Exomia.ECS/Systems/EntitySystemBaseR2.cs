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
    ///     An entity system base r 2.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    public abstract class EntitySystemBaseR2<TComponent1, TComponent2> : EntitySystemBase
        where TComponent1 : IEntityComponent
        where TComponent2 : IEntityComponent
    {
        /// <summary>
        ///     The first components.
        /// </summary>
        protected TComponent1[] _components1;

        /// <summary>
        ///     The second components.
        /// </summary>
        protected TComponent2[] _components2;

        /// <summary>
        ///     Initializes a new instance of the &lt;see cref="EntitySystemBaseR2&lt;TComponent1,
        ///     TComponent2&gt;"/&gt; class.
        /// </summary>
        /// <param name="manager"> The manager. </param>
        protected EntitySystemBaseR2(EntityManager manager)
            : base(manager)
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap]  = default!;

            _components2[index] = _components2[swap];
            _components2[swap]  = default!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
        }

        /// <inheritdoc />
        protected override void UpdateOrDraw(GameTime gameTime, Entity entity, int index)
        {
            UpdateOrDraw(gameTime, entity, _components1[index], _components2[index]);
        }

        /// <summary>
        ///     Updates or draws the system.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1">       The first TComponent1. </param>
        /// <param name="c2">       The second TComponent2. </param>
        protected abstract void UpdateOrDraw(GameTime gameTime, Entity entity, TComponent1 c1, TComponent2 c2);

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
        }
    }
}