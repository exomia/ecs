#region License

// Copyright (c) 2018-2019, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Threading.Tasks;
using Exomia.Framework.Game;

namespace Exomia.ECS.Systems
{
    /// <summary>
    ///     An entity system parallel base.
    /// </summary>
    public abstract class EntitySystemParallelBase : EntitySystemBase
    {
        /// <summary>
        ///     Options for controlling the parallel.
        /// </summary>
        private readonly ParallelOptions _parallelOptions;

        /// <inheritdoc />
        protected EntitySystemParallelBase(EntityManager manager, int maxDegreeOfParallelism = 2)
            : base(manager)
        {
            if (maxDegreeOfParallelism <= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(maxDegreeOfParallelism), "value must be greater than 1");
            }
            _parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxDegreeOfParallelism };
        }

        /// <inheritdoc />
        internal override void UpdateOrDraw(GameTime gameTime)
        {
            Parallel.For(
                0, _entitiesCount, _parallelOptions, i =>
                {
                    UpdateOrDraw(gameTime, _entities[i], i);
                });
        }
    }
}