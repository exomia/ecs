#region License

// Copyright (c) 2018-2020, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;
using Exomia.ECS.Systems;

namespace Exomia.ECS.Attributes
{
    /// <summary> Attribute for entity system configuration. This class cannot be inherited. </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EntitySystemConfigurationAttribute : Attribute
    {
        /// <summary>
        ///     The name.
        /// </summary>
        internal readonly string Name;

        /// <summary> Gets or sets the list of system names which has to be executed after this one. </summary>
        /// <value> The after. </value>
        public string[]? After { get; set; }

        /// <summary> Gets or sets the list of system names which has to be executed before this one. </summary>
        /// <value> The before. </value>
        public string[]? Before { get; set; }

        /// <summary> Gets or sets a system name to be replaced with this one. </summary>
        /// <value> The replace. </value>
        public string? Replace { get; set; }

        /// <summary> Gets or sets the manager flags. </summary>
        /// <remarks>
        ///     The <see cref="ManagerFlags" /> will be used to determine if an <see cref="Entity" />
        ///     will be added to an <see cref="EntityManager" />.
        ///     e.g. If the manager flags is set to 3 all entities who have their first 2 bits set will be added to this system. But they will be added to managers with manager flags
        ///     set to 1 or 2 as well.
        /// </remarks>
        /// <value> The manager flags. </value>
        public uint ManagerFlags { get; set; }

        /// <summary> Gets or sets the system mask. </summary>
        /// <remarks>
        ///     The <see cref="SystemMask" /> will be used to determine if an <see cref="Entity" />
        ///     will be added to an <see cref="EntitySystemBase" />.
        ///     e.g. If the system mask is set to 3 all entities who have their first 2 bits set will be added to this system. But they will be added to systems with system mask set to
        ///     1 or 2 as well.
        /// </remarks>
        /// <value> The system mask. </value>
        public uint SystemMask { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemConfigurationAttribute" />
        ///     class.
        /// </summary>
        /// <param name="name"> The name. </param>
        public EntitySystemConfigurationAttribute(string name)
        {
            Name = name;
        }
    }
}