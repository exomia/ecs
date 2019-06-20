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
    ///     An entity. This class cannot be inherited.
    /// </summary>
    public sealed class Entity
    {

        /// <summary>
        ///     Initial size of the components.
        /// </summary>
        private const int INITIAL_COMPONENTS_SIZE = 8;


        /// <summary>
        ///     Unique identifier.
        /// </summary>
        public readonly Guid Guid;


        /// <summary>
        ///     The name.
        /// </summary>
        public string Name;


        /// <summary>
        ///     True if this object is initialized.
        /// </summary>
        internal bool _isInitialized = false;


        /// <summary>
        ///     The components.
        /// </summary>
        private readonly Dictionary<Type, IEntityComponent> _components;


        /// <summary>
        ///     Gets the components.
        /// </summary>
        /// <value>
        ///     The components.
        /// </value>
        internal IEnumerable<IEntityComponent> Components
        {
            get { return _components.Values; }
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="guid"> Unique identifier. </param>
        internal Entity(Guid guid)
        {
            Guid        = guid;
            _components = new Dictionary<Type, IEntityComponent>(INITIAL_COMPONENTS_SIZE);
        }


        /// <summary>
        ///     Gets a bool using the given component.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="component"> [out] The component. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool Get<T>(out T component) where T : IEntityComponent
        {
            bool res = _components.TryGetValue(typeof(T), out IEntityComponent c);
            component = (T)c;
            return res;
        }


        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Entity other)
            {
                return Guid.Equals(other.Guid);
            }
            return obj?.Equals(this) ?? false;
        }


        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }


        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[{Name}:{Guid}]";
        }


        /// <summary>
        ///     Adds component.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="component"> The component. </param>
        internal void Add<T>(T component) where T : IEntityComponent
        {
            _components.Add(typeof(T), component);
        }


        /// <summary>
        ///     Removes this object.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        internal bool Remove<T>() where T : IEntityComponent
        {
            return _components.Remove(typeof(T));
        }
    }
}