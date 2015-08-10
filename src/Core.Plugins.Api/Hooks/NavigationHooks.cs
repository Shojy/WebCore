#region Header

// <copyright company="Joshua Moon" file="NavigationHooks.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// NavigationHooks.cs is a part of the project Core.Plugins.Api.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core.Plugins.Api.Hooks
{
    using System.Collections.Generic;

    /// <summary>
    /// The navigation hooks.
    /// </summary>
    public abstract class NavigationHooks : INavigationHooks
    {
        #region Public Properties

        /// <summary>
        /// Gets the footer menu navigation items.
        /// </summary>
        public virtual List<object> FooterMenuNavigationItems { get; }

        /// <summary>
        /// Gets the main menu navigation items.
        /// </summary>
        public virtual List<object> MainMenuNavigationItems { get; }

        /// <summary>
        /// Gets the tile groups.
        /// </summary>
        public virtual List<object> TileGroups { get; }

        #endregion Public Properties
    }
}