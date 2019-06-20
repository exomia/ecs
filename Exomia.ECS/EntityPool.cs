#region License

// Copyright (c) 2018-2019, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

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
        ///     Initializes a new instance of the <see cref="EntityPool" /> class.
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