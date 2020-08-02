#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System.Collections.Generic;

namespace Exomia.ECS.Events
{    
    /// <summary>
    ///     callback handler.
    /// </summary>
    /// <typeparam name="T1"> Generic type parameter. </typeparam>
    /// <returns>
    ///     A ref T1.
    /// </returns>
    public delegate ref T1 RR<T1>();
    
    /// <summary>
    ///     A handler. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T1"> Generic type parameter. </typeparam>
    sealed class RrHandler<T1>
    {
        private static readonly Dictionary<string, RR<T1>> s_callbacks;

        /// <summary>
        ///     Initializes static members of the <see cref="RrHandler{T1}" /> class.
        /// </summary>
        static RrHandler()
        {
            s_callbacks = new Dictionary<string, RR<T1>>(16);
        }

        internal static void Register(string key, RR<T1> callback)
        {
            s_callbacks[key] = callback;
        }

        internal static bool Unregister(string key)
        {
            return s_callbacks.Remove(key);
        }

        internal static bool Get(string key, out RR<T1> r)
        {
            return s_callbacks.TryGetValue(key, out r);
        }
    }
}