#region Header
// <copyright company="Italik Ltd." file="PluginAreaRegistration.cs">
// Copyright (c) 2015 Italik Ltd. All Rights Reserved.
// </copyright>
// <summary>
// PluginAreaRegistration.cs is a part of the project Plugin. 
// </summary>
// <author>Joshua Moon</author>
#endregion
namespace Plugin
{
    using System.Web.Mvc;

    /// <summary>
    /// Registers the plugin areas
    /// </summary>
    public class PluginAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Unique Plugin Name
        /// </summary>
        public override string AreaName
        {
            get { return "Plugin"; }
        }

        /// <summary>
        /// Registers a plugins area to the context
        /// </summary>
        /// <param name="context">Area context</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Plugin", 
                "Plugin/{controller}/{action}/{id}", 
                new { controller = "Plugin", action = "Index", id = UrlParameter.Optional },
                new[] { "Plugin.Controllers" });
        } 
    }
}