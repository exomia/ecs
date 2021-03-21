#region License

// Copyright (c) 2018-2021, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Collections.Generic;

namespace Exomia.ECS
{
    internal sealed class EntityPool
    {
        private readonly Stack<Entity> _free;

        internal EntityPool(int initialSize)
        {
            _free = new Stack<Entity>(initialSize);
            for (int i = 0; i < initialSize; i++)
            {
                _free.Push(new Entity());
            }
        }

        internal void Release(Entity entity)
        {
            lock (_free)
            {
                entity.IsInitialized = false;
                _free.Push(entity);
            }
        }

        internal Entity Take(Guid guid)
        {
            lock (_free)
            {
                if (_free.Count > 0)
                {
                    Entity entity = _free.Pop();
                    entity.Guid = guid;
                    return entity;
                }
            }
            return new Entity {Guid = guid};
        }
    }
}