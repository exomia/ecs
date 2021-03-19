#region License

// Copyright (c) 2018-2021, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;

namespace Exomia.ECS.Attributes
{
    /// <summary> Attribute for entity component configuration. This class cannot be inherited. </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EntityComponentConfigurationAttribute : Attribute
    {
        internal bool UsePooling;

        /// <summary> Gets or sets the pool size. </summary>
        /// <value> The size of the pool. </value>
        public int PoolSize { get; set; } = EntityManager.INITIAL_ARRAY_SIZE;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityComponentConfigurationAttribute" /> class.
        /// </summary>
        /// <param name="usePooling"> (Optional) True to use pooling. </param>
        public EntityComponentConfigurationAttribute(bool usePooling = true)
        {
            UsePooling = usePooling;
        }
    }
}