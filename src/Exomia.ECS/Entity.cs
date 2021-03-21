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
    /// <summary> An entity. This class cannot be inherited. </summary>
    public sealed class Entity
    {
        private const int INITIAL_COMPONENTS_SIZE = 8;

        internal         bool                     IsInitialized = false;
        internal         uint                     SystemFlags   = 0u;
        private readonly Dictionary<Type, object> _components;

        /// <summary> Unique identifier. </summary>
        /// <value> The identifier of the unique. </value>
        public Guid Guid { get; internal set; }

        internal IEnumerable<object> Components
        {
            get { return _components.Values; }
        }

        internal Entity()
        {
            _components = new Dictionary<Type, object>(INITIAL_COMPONENTS_SIZE);
        }

        /// <summary> Gets a bool using the given component. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="component"> [out] The component. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        public bool Get<T>(out T component)
            where T : class
        {
            bool res = _components.TryGetValue(typeof(T), out object c);
            component = (T)c;
            return res;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return obj is Entity other && Guid.Equals(other.Guid);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            // ReSharper disable once NonReadonlyMemberInGetHashCode
            return Guid.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"[{Guid.ToString()}]";
        }

        internal void Add<T>(T component)
            where T : class
        {
#if DEBUG
            if (component == null) { throw new ArgumentNullException(nameof(component)); }
#endif
            _components.Add(typeof(T), component!);
        }

        internal bool Remove<T>()
            where T : class
        {
            return _components.Remove(typeof(T));
        }
    }
}