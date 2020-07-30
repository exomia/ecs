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
    /// <typeparam name="T2"> Generic type parameter. </typeparam>
    /// <typeparam name="T3"> Generic type parameter. </typeparam>
    /// <typeparam name="T4"> Generic type parameter. </typeparam>
    /// <param name="o1"> [out] The first out T1. </param>
    /// <param name="o2"> [out] The second out T2. </param>
    /// <param name="o3"> [out] The third out T3. </param>
    /// <param name="o4"> [out] The fourth out T4. </param>
    public delegate void O<T1, T2, T3, T4>(out T1 o1, out T2 o2, out T3 o3, out T4 o4);

    /// <summary>
    ///     A handler. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T1"> Generic type parameter. </typeparam>
    /// <typeparam name="T2"> Generic type parameter. </typeparam>
    /// <typeparam name="T3"> Generic type parameter. </typeparam>
    /// <typeparam name="T4"> Generic type parameter. </typeparam>
    sealed class OHandler<T1, T2, T3, T4>
    {
        /// <summary>
        ///     The callbacks.
        /// </summary>
        private static readonly Dictionary<string, O<T1, T2, T3, T4>> s_callbacks;

        /// <summary>
        ///     Initializes static members of the <see cref="OHandler{T1,T2,T3,T4}" /> class.
        /// </summary>
        static OHandler()
        {
            s_callbacks = new Dictionary<string, O<T1, T2, T3, T4>>(16);
        }

        internal static void Register(string key, O<T1, T2, T3, T4> callback)
        {
            s_callbacks[key] = callback;
        }

        internal static bool Unregister(string key)
        {
            return s_callbacks.Remove(key);
        }

        internal static bool Get(string key, out O<T1, T2, T3, T4> o)
        {
            return s_callbacks.TryGetValue(key, out o);
        }
    }
}