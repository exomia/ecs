﻿#region License

// Copyright (c) 2018-2019, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        public string? Name;

        /// <summary>
        ///     True if this object is initialized.
        /// </summary>
        internal bool _isInitialized = false;

        /// <summary>
        ///     The components.
        /// </summary>
        private readonly Dictionary<Type, object> _components;

        /// <summary>
        ///     Gets the components.
        /// </summary>
        /// <value>
        ///     The components.
        /// </value>
        internal IEnumerable<object> Components
        {
            get { return _components.Values; }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Entity" /> class.
        /// </summary>
        /// <param name="guid"> Unique identifier. </param>
        internal Entity(Guid guid)
        {
            Guid        = guid;
            _components = new Dictionary<Type, object>(INITIAL_COMPONENTS_SIZE);
        }

        /// <summary>
        ///     Gets a bool using the given component.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="component"> [out] The component. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        public bool Get<T>(out T component)
        {
            bool res = _components.TryGetValue(typeof(T), out object c);
            component = (T)c;
            return res;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is Entity other)
            {
                return Guid.Equals(other.Guid);
            }
            return obj?.Equals(this) ?? false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"[{Name}:{Guid}]";
        }

        /// <summary>
        ///     Adds component.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="component"> The component. </param>
        internal void Add<T>(T component)
        {
            Debug.Assert(component != null, nameof(component) + " != null");
            _components.Add(typeof(T), component!);
        }

        /// <summary>
        ///     Removes this object.
        /// </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        internal bool Remove<T>()
        {
            return _components.Remove(typeof(T));
        }
    }
}