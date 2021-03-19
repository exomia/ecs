#region License

// Copyright (c) 2018-2021, exomia
// All rights reserved.
// 
// This source code is licensed under the BSD-style license found in the
// LICENSE file in the root directory of this source tree.

#endregion

using Exomia.Framework.Game;

namespace Exomia.ECS.Systems
{
    /// <summary> Interface for updateable system. </summary>
    public interface IUpdateableSystem
    {
        /// <summary> Gets or sets a value indicating whether the game component's Update method should be called. </summary>
        /// <value> <c>true</c> if update is enabled; otherwise, <c>false</c>. </value>
        bool Enabled { get; set; }

        /// <summary> This method is called when this game component is updated. </summary>
        /// <param name="gameTime"> The current timing. </param>
        void Update(GameTime gameTime);
    }
}