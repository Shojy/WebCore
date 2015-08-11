#region Header

// <copyright company="Joshua Moon" file="BundleConfig.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// BundleConfig.cs is a part of the project Core.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core
{
    using System.Web.Optimization;

    using Core.Plugins.Api.Hooks;
    using Core.Plugins.Api.Hooks.Communications;

    /// <summary>
    /// The bundle config.
    /// </summary>
    public class BundleConfig
    {
        #region Public Methods

        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when
            // you're ready for production, use the build tool at http://modernizr.com to pick only
            // the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(
                new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/css/bootstrap.css", "~/Content/css/site.css"));

            // Run bundles hook in plugins
            HooksHandler.RunHooks<IApplicationStartHooks>("RegisterBundles", bundles);
        }

        #endregion Public Methods
    }
}