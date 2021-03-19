#region License

// Copyright (c) 2018-2021, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System.Collections.Generic;

namespace Exomia.ECS.Events
{
    /// <summary> callback handler. </summary>
    /// <typeparam name="T1"> Generic type parameter. </typeparam>
    /// <returns> A ref T1. </returns>
    public delegate T1 R<out T1>();

    internal sealed class RHandler<T1>
    {
        private static readonly Dictionary<string, R<T1>> s_callbacks;

        static RHandler()
        {
            s_callbacks = new Dictionary<string, R<T1>>(16);
        }

        internal static void Register(string key, R<T1> callback)
        {
            s_callbacks[key] = callback;
        }

        internal static bool Unregister(string key)
        {
            return s_callbacks.Remove(key);
        }

        internal static bool Get(string key, out R<T1> r)
        {
            return s_callbacks.TryGetValue(key, out r);
        }
    }
}