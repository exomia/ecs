#region License

// Copyright (c) 2018-2019, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;

namespace Exomia.ECS.Attributes
{
    /// <summary>
    ///     Values that represent EntitySystemType.
    /// </summary>
    public enum EntitySystemType
    {
        /// <summary>
        ///     An enum constant representing the update option.
        /// </summary>
        Update,

        /// <summary>
        ///     An enum constant representing the draw option.
        /// </summary>
        Draw
    }

    /// <summary>
    ///     Attribute for entity system configuration. This class cannot be inherited.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EntitySystemConfigurationAttribute : Attribute
    {
        /// <summary>
        ///     Type of the entity system.
        /// </summary>
        internal readonly EntitySystemType EntitySystemType;

        /// <summary>
        ///     The name.
        /// </summary>
        internal readonly string Name;

        /// <summary>
        ///     get or set the list of system names which has to be executed after this one.
        /// </summary>
        /// <value>
        ///     The after.
        /// </value>
        public string[] After { get; set; }

        /// <summary>
        ///     get or set the list of system names which has to be executed before this one.
        /// </summary>
        /// <value>
        ///     The before.
        /// </value>
        public string[] Before { get; set; }

        /// <summary>
        ///     get or set a system name to be replaced with this one.
        /// </summary>
        /// <value>
        ///     The replace.
        /// </value>
        public string Replace { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EntitySystemConfigurationAttribute" />
        ///     class.
        /// </summary>
        /// <param name="name">             The name. </param>
        /// <param name="entitySystemType"> Type of the entity system. </param>
        public EntitySystemConfigurationAttribute(string name, EntitySystemType entitySystemType)
        {
            Name             = name;
            EntitySystemType = entitySystemType;
        }
    }
}