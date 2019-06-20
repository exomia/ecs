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
using System.Collections.Generic;

namespace Exomia.ECS
{
    /// <summary>
    ///     An entity pool. This class cannot be inherited.
    /// </summary>
    sealed class EntityPool
    {
        /// <summary>
        ///     The free.
        /// </summary>
        private readonly Stack<Entity> _free;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityPool"/> class.
        /// </summary>
        /// <param name="initialSize"> Size of the initial. </param>
        internal EntityPool(int initialSize)
        {
            _free = new Stack<Entity>(initialSize);
            for (int i = 0; i < initialSize; i++)
            {
                _free.Push(new Entity(Guid.NewGuid()));
            }
        }

        /// <summary>
        ///     Releases the given entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        internal void Release(Entity entity)
        {
            lock (_free)
            {
                entity._isInitialized = false;
                _free.Push(entity);
            }
        }

        /// <summary>
        ///     Gets the take.
        /// </summary>
        /// <returns>
        ///     An Entity.
        /// </returns>
        internal Entity Take()
        {
            lock (_free)
            {
                if (_free.Count > 0)
                {
                    return _free.Pop();
                }
            }
            return new Entity(Guid.NewGuid());
        }
    }
}