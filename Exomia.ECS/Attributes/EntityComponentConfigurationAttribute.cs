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

namespace Exomia.ECS.Attributes
{

    /// <summary>
    ///     Attribute for entity component configuration. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EntityComponentConfigurationAttribute : Attribute
    {
        /// <summary>
        ///     Size of the pool.
        /// </summary>
        public int PoolSize = EntityManager.INITIAL_ARRAY_SIZE;
        /// <summary>
        ///     True to use pooling.
        /// </summary>
        internal bool _usePooling;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntityComponentConfigurationAttribute"/>
        ///     class.
        /// </summary>
        /// <param name="usePooling"> True to use pooling. </param>
        public EntityComponentConfigurationAttribute(bool usePooling = true)
        {
            _usePooling = usePooling;
        }
    }
}