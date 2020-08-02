#region License

// Copyright (c) 2018-2020, exomia
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
    ///     An entity system base r 3.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    /// <typeparam name="TComponent2"> Type of the component 2. </typeparam>
    /// <typeparam name="TComponent3"> Type of the component 3. </typeparam>
    /// <typeparam name="TComponent4"> Type of the component 4. </typeparam>
    public abstract class EntitySystemBaseR4<TComponent1, TComponent2, TComponent3, TComponent4> : EntitySystemBase
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
        ///     The second components.
        /// </summary>
        protected TComponent3[] _components3;
        
        /// <summary>
        ///     The second components.
        /// </summary>
        protected TComponent4[] _components4;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemBaseR2{TComponent1, TComponent2}" /> class.
        /// </summary>
        /// <param name="manager"> The manager. </param>
        protected EntitySystemBaseR4(EntityManager manager)
            : base(manager)
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
            _components2 = new TComponent2[EntityManager.INITIAL_ARRAY_SIZE];
            _components3 = new TComponent3[EntityManager.INITIAL_ARRAY_SIZE];
            _components4 = new TComponent4[EntityManager.INITIAL_ARRAY_SIZE];
        }

        /// <inheritdoc />
        protected override bool Add(Entity entity, int index)
        {
            return
                entity.Get(out _components1[index]) &&
                entity.Get(out _components2[index]) &&
                entity.Get(out _components3[index]) &&
                entity.Get(out _components4[index]);
        }

        /// <inheritdoc />
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap]  = default!;

            _components2[index] = _components2[swap];
            _components2[swap]  = default!;

            _components3[index] = _components3[swap];
            _components3[swap]  = default!;
            
            _components4[index] = _components4[swap];
            _components4[swap]  = default!;
        }

        /// <inheritdoc />
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
            Array.Resize(ref _components2, size);
            Array.Resize(ref _components3, size);
            Array.Resize(ref _components4, size);
        }

        /// <inheritdoc />
        protected override void Tick(GameTime gameTime, Entity entity, int index)
        {
            Tick(gameTime, entity, _components1[index], _components2[index], _components3[index], _components4[index]);
        }

        /// <summary>
        ///     Ticks every frame.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1">       The <typeparamref name="TComponent1"/>. </param>
        /// <param name="c2">       The <typeparamref name="TComponent2"/>. </param>
        /// <param name="c3">       The <typeparamref name="TComponent3"/>. </param>
        /// <param name="c4">       The <typeparamref name="TComponent4"/>. </param>
        protected abstract void Tick(GameTime gameTime, Entity entity, TComponent1 c1, TComponent2 c2, TComponent3 c3, TComponent4 c4);

        /// <inheritdoc />
        protected override void OnDispose(bool disposing)
        {
            _components1 = null!;
            _components2 = null!;
            _components3 = null!;
            _components4 = null!;
        }
    }
}