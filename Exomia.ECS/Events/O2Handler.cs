#region License

// Copyright (c) 2018-2019, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System.Collections.Generic;

namespace Exomia.ECS.Events
{
    /// <summary>
    ///     Operating system.
    /// </summary>
    /// <typeparam name="T1"> Generic type parameter. </typeparam>
    /// <typeparam name="T2"> Generic type parameter. </typeparam>
    /// <param name="o1"> [out] The first out T1. </param>
    /// <param name="o2"> [out] The second out T2. </param>
    public delegate void O<T1, T2>(out T1 o1, out T2 o2);

    /// <summary>
    ///     A handler. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T1"> Generic type parameter. </typeparam>
    /// <typeparam name="T2"> Generic type parameter. </typeparam>
    sealed class OHandler<T1, T2>
    {
        /// <summary>
        ///     The callbacks.
        /// </summary>
        private static readonly Dictionary<string, O<T1, T2>> s_callbacks;

        /// <summary>
        ///     Initializes static members of the <see cref="OHandler{T1,T2}" /> class.
        /// </summary>
        static OHandler()
        {
            s_callbacks = new Dictionary<string, O<T1, T2>>(16);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        internal static void Register(string key, O<T1, T2> callback)
        {
            s_callbacks[key] = callback;
        }

        /// <summary>
        ///     De register.
        /// </summary>
        /// <param name="key"> The key. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        internal static bool DeRegister(string key)
        {
            return s_callbacks.Remove(key);
        }

        /// <summary>
        ///     Gets.
        /// </summary>
        /// <param name="key"> The key. </param>
        /// <param name="o">   [out] The out <see cref="O{T1,T2}" /> to process. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        internal static bool Get(string key, out O<T1, T2> o)
        {
            return s_callbacks.TryGetValue(key, out o);
        }
    }
}