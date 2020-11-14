#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            where TComponent : class
        {
            EntityComponentPool<TComponent>.Release(component);
        }
    }

    /// <summary>
    ///     An entity component pool.
    /// </summary>
    /// <typeparam name="TComponent"> Type of the component. </typeparam>
    static class EntityComponentPool<TComponent> 
        where  TComponent : class
    {
        private static readonly bool              s_usePooling;
        private static readonly Stack<TComponent> s_free = null!;
        private static readonly Func<TComponent>  s_getInstance;

        /// <summary>
        ///     Initializes static members of the <see cref="EntityComponentPool{TComponent}" /> class.
        /// </summary>
        static EntityComponentPool()
        {
            s_getInstance = Expression.Lambda<Func<TComponent>>(Expression.New(typeof(TComponent))).Compile();

            EntityComponentConfigurationAttribute cfg =
                typeof(TComponent).GetCustomAttribute<EntityComponentConfigurationAttribute>(false)
             ?? new EntityComponentConfigurationAttribute();

            s_usePooling = cfg._usePooling;
            if (!s_usePooling) { return; }

            s_free = new Stack<TComponent>(cfg.PoolSize);
            for (int i = 0; i < cfg.PoolSize; i++)
            {
                s_free.Push(s_getInstance());
            }
        }

        internal static TComponent Create()
        {
            return s_getInstance();
        }

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
            return s_getInstance();
        }
    }
}