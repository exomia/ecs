#region License

// Copyright (c) 2018-2021, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System.Reflection;
using System.Runtime.CompilerServices;
using Exomia.ECS.Systems;

namespace Exomia.ECS
{
    /// <content> Manager for entities. This class cannot be inherited. </content>
    public sealed partial class EntityManager
    {
        /// <summary> Attempts to get an <see cref="EntitySystemBase" /> from the given name. </summary>
        /// <param name="name">   The name. </param>
        /// <param name="system"> [out] The system. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetSystem(string name, out EntitySystemBase system)
        {
            return _entitySystemsMap.TryGetValue(name, out system);
        }

        /// <summary> Attempts to get an <see cref="EntitySystemBase" /> from the given name. </summary>
        /// <typeparam name="T"> Generic type parameter. </typeparam>
        /// <param name="name">   The name. </param>
        /// <param name="system"> [out] The system cast to <typeparamref name="T" />. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetSystem<T>(string name, out T system)
        {
            if (TryGetSystem(name, out EntitySystemBase s))
            {
                system = (T)(object)s;
                return true;
            }
            system = default!;
            return false;
        }

        /// <summary> Attempts to get an <see cref="EntitySystemBase" /> from the given name. </summary>
        /// <typeparam name="T"> any interface. </typeparam>
        /// <param name="system"> [out] The system cast to <typeparamref name="T" />. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        /// <exception cref="AmbiguousMatchException"> Thrown when the Ambiguous Match error condition occurs. </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetSystem<T>(out T system)
            where T : class
        {
#if DEBUG
            if (!typeof(T).IsInterface)
            {
                throw new AmbiguousMatchException(
                    "The typeof(T) is not an interface and could be ambiguous or not the expected result!");
            }
#endif
            if (_entitySystemInterfaces.TryGetValue(typeof(T), out EntitySystemBase s))
            {
                system = (T)(object)s;
                return true;
            }
            system = default!;
            return false;
        }
    }
}