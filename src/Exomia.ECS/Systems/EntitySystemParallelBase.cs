#region License

// Copyright (c) 2018-2020, exomia
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
        private readonly ParallelOptions _parallelOptions;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemParallelBase" /> class.
        /// </summary>
        /// <param name="manager">                The <see cref="EntityManager" />. </param>
        /// <param name="maxDegreeOfParallelism"> (Optional) The maximum degree of parallelism. </param>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown when one or more arguments are outside the required range. </exception>
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
        public override void Tick(GameTime gameTime)
        {
            Parallel.For(
                0, _entitiesCount, _parallelOptions, i =>
                {
                    Tick(gameTime, _entities[i], i);
                });
        }
    }
}