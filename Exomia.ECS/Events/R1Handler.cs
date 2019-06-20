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
        ///     Initializes static members of the <see cref="RHandler{T1}"/> class.
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
        /// <param name="r">   [out] The out <see cref="R{T1}"/> to process. </param>
        /// <returns>
        ///     True if it succeeds, false if it fails.
        /// </returns>
        internal static bool Get(string key, out R<T1> r)
        {
            return s_callbacks.TryGetValue(key, out r);
        }
    }
}