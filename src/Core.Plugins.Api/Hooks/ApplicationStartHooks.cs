#region Header

// <copyright company="Joshua Moon" file="ApplicationStartHooks.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// ApplicationStartHooks.cs is a part of the project Core.Plugins.Api.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core.Plugins.Api.Hooks
{
    using System.Web.Optimization;

    /// <summary>
    /// The application start hooks.
    /// </summary>
    public abstract class ApplicationStartHooks : IApplicationStartHooks
    {
        #region Public Methods

        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public virtual void RegisterBundles(BundleCollection bundles)
        {
        }

        #endregion Public Methods
    }
}