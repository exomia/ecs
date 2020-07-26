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
    ///     Gets the r.
    /// </summary>
    /// <typeparam name="T1"> Generic type parameter. </typeparam>
    /// <returns>
    ///     A ref T1.
    /// </returns>
    public delegate ref T1 R<T1>();

    /// <summary>
    ///     A handler. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T1"> Generic type parameter. </typeparam>
    sealed class RHandler<T1>
    {
        /// <summary>
        ///     The callbacks.
        /// </summary>
        private static readonly Dictionary<string, R<T1>> s_callbacks;

        /// <summary>
        ///     Initializes static members of the <see cref="RHandler{T1}" /> class.
        /// </summary>
        static RHandler()
        {
            s_callbacks = new Dictionary<string, R<T1>>(16);
        }

        /// <summary>
        ///     Registers this object.
        /// </summary>
        /// <param name="key">      The key. </param>
        /// <param name="callback"> The callback. </param>
        internal static void Register(string key, R<T1> callback)
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
        /// <param name="r">   [out] The out <see cref="R{T1}" /> to process. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        internal static bool Get(string key, out R<T1> r)
        {
            return s_callbacks.TryGetValue(key, out r);
        }
    }
}