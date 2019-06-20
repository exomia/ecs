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
        ///     Initializes static members of the <see cref="EntityComponentPool{TComponent}"/> class.
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