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
        internal readonly string           Name;

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
        ///     Initializes a new instance of the <see cref="EntitySystemConfigurationAttribute"/>
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