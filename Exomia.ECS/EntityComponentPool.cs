#region License

// Copyright (c) 2018-2019, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System.Collections.Generic;
using System.Reflection;
using Exomia.ECS.Attributes;

// ReSharper disable StaticMemberInGenericType

namespace Exomia.ECS
{
    /// <summary>
    ///     An entity component pool.
    /// </summary>
    static class EntityComponentPool
    {
        /// <summary>
        ///     Releases the given component.
        /// </summary>
        /// <typeparam name="TComponent"> Type of the component. </typeparam>
        /// <param name="component"> The component. </param>
        public static void Release<TComponent>(TComponent component)
            where TComponent : IEntityComponent, new()
        {
            EntityComponentPool<TComponent>.Release(component);
        }
    }

    /// <summary>
    ///     An entity component pool.
    /// </summary>
    /// <typeparam name="TComponent"> Type of the component. </typeparam>
    static class EntityComponentPool<TComponent>
        where TComponent : IEntityComponent, new()
    {
        /// <summary>
        ///     True to use pooling.
        /// </summary>
        private static readonly bool s_usePooling;

        /// <summary>
        ///     The free.
        /// </summary>
        private static readonly Stack<TComponent> s_free;

        /// <summary>
        ///     Initializes static members of the <see cref="EntityComponentPool{TComponent}" /> class.
        /// </summary>
        static EntityComponentPool()
        {
            EntityComponentConfigurationAttribute cfg =
                typeof(TComponent).GetCustomAttribute<EntityComponentConfigurationAttribute>(false)
             ?? new EntityComponentConfigurationAttribute();

            s_usePooling = cfg._usePooling;
            if (!s_usePooling) { return; }

            s_free = new Stack<TComponent>(cfg.PoolSize);
            for (int i = 0; i < cfg.PoolSize; i++)
            {
                s_free.Push(new TComponent());
            }
        }

        /// <summary>
        ///     Releases the given component.
        /// </summary>
        /// <param name="component"> The component. </param>
        internal static void Release(TComponent component)
        {
            if (s_usePooling)
            {
                lock (s_free)
                {
                    s_free.Push(component);
                }
            }
        }

        /// <summary>
        ///     Gets an component from the pool or create a new one
        /// </summary>
        /// <returns>
        ///     A TComponent.
        /// </returns>
        internal static TComponent Take()
        {
            if (s_usePooling)
            {
                lock (s_free)
                {
                    if (s_free.Count > 0)
                    {
                        return s_free.Pop();
                    }
                }
            }
            return new TComponent();
        }
    }
}