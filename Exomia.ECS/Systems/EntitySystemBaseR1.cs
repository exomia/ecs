
#region MIT License

// Copyright (c) 2019 exomia - Daniel Bätz
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

#endregion

using System;
using Exomia.Framework.Game;

namespace Exomia.ECS.Systems
{

    /// <summary>
    ///     An entity system base r 1.
    /// </summary>
    /// <typeparam name="TComponent1"> Type of the component 1. </typeparam>
    public abstract class EntitySystemBaseR1<TComponent1> : EntitySystemBase
        where TComponent1 : IEntityComponent
    {

        /// <summary>
        ///     The first components.
        /// </summary>
        protected TComponent1[] _components1;


        /// <summary>
        ///     Initializes a new instance of the &lt;see cref="EntitySystemBaseR1&lt;TComponent1&gt;
        ///     "/&gt; class.
        /// </summary>
        /// <param name="manager"> The manager. </param>
        protected EntitySystemBaseR1(EntityManager manager)
            : base(manager)
        {
            _components1 = new TComponent1[EntityManager.INITIAL_ARRAY_SIZE];
        }


        /// <inheritdoc/>
        protected override bool Add(Entity entity, int index)
        {
            return entity.Get(out _components1[index]);
        }


        /// <inheritdoc/>
        protected override void Remove(int index, int swap)
        {
            _components1[index] = _components1[swap];
            _components1[swap]  = default;
        }


        /// <inheritdoc/>
        protected override void Grow(int size)
        {
            Array.Resize(ref _components1, size);
        }


        /// <inheritdoc/>
        protected override void UpdateOrDraw(GameTime gameTime, Entity entity, int index)
        {
            UpdateOrDraw(gameTime, entity, _components1[index]);
        }


        /// <summary>
        ///     Updates or draws the system.
        /// </summary>
        /// <param name="gameTime"> The game time. </param>
        /// <param name="entity">   The entity. </param>
        /// <param name="c1">       The first TComponent1. </param>
        protected abstract void UpdateOrDraw(GameTime gameTime, Entity entity, TComponent1 c1);


        /// <inheritdoc/>
        protected override void OnDispose(bool disposing)
        {
            _components1 = null;
        }
    }
}