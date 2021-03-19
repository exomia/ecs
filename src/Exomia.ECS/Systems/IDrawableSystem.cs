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
    /// <summary> Interface for drawable system. </summary>
    public interface IDrawableSystem
    {
        /// <summary>
        ///     Gets a value indicating whether the <see cref="Draw(GameTime)" /> method should be called by the
        ///     <see cref="EntityManager" />.
        /// </summary>
        /// <value> <c>true</c> if this drawable component is visible; otherwise, <c>false</c>. </value>
        bool Visible { get; }

        /// <summary>
        ///     Starts the drawing of a frame. This method is followed by calls to <see cref="Draw(GameTime)" /> and
        ///     <see cref="EndDraw" />.
        /// </summary>
        /// <returns>
        ///     <c>true</c> if the <see cref="Draw(Exomia.Framework.Game.GameTime)" /> method should be called,
        ///     <c>false</c> otherwise.
        /// </returns>
        bool BeginDraw();

        /// <summary> Draws this instance. This method is followed by <see cref="EndDraw" />. </summary>
        /// <param name="gameTime"> The current timing. </param>
        void Draw(GameTime gameTime);

        /// <summary>
        ///     Ends the drawing of a frame. This method is preceded by calls to <see cref="Draw(GameTime)" /> and
        ///     <see cref="BeginDraw" />.
        /// </summary>
        void EndDraw();
    }
}