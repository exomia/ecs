#region License

// Copyright (c) 2018-2021, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using System;

namespace Exomia.ECS
{
    /// <content> Manager for entities. This class cannot be inherited. </content>
    public sealed partial class EntityManager
    {
        /// <summary> Adds a template to 'initialize' an <see cref="Entity" /> from. </summary>
        /// <param name="template">   The template. </param>
        /// <param name="initialize"> The initialize. </param>
        public void AddTemplate(string template, Action<EntityManager, Entity> initialize)
        {
            lock (_initialTemplates)
            {
                _initialTemplates.Add(template, initialize);
            }
        }

        /// <summary> Removes the template described by template. </summary>
        /// <param name="template"> The template. </param>
        /// <returns> True if it succeeds, false if it fails. </returns>
        public bool RemoveTemplate(string template)
        {
            lock (_initialTemplates)
            {
                return _initialTemplates.Remove(template);
            }
        }
    }
}