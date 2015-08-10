#region Header

// <copyright company="Joshua Moon" file="Plugin.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// Plugin.cs is a part of the project Core.Plugins.Api.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core.Plugins.Api
{
    using System.Reflection;
    using System.Web;

    /// <summary>
    /// Provides plugin utility methods.
    /// </summary>
    public static class Plugin
    {
        #region Public Methods

        /// <summary>
        /// Translates a plugin-rooted virtual path to an application-rooted virtual path.
        /// </summary>
        /// <param name="path">Virtual path to translate</param>
        /// <returns>Virtual path based on application root.</returns>
        public static string ToAppVirtualPath(string path)
        {
            // If this isn't a virtual path, simply return the path unchanged.
            if (!path.StartsWith("~/"))
            {
                return path;
            }

            var assembly = Assembly.GetCallingAssembly();
            var appPath = HttpContext.Current.Request.MapPath("~/").TrimEnd('\\', '/');
            var pluginPath = assembly.Location.Substring(appPath.Length - 1);
            var parts = pluginPath.Split('/', '\\');
            path = string.Format("~/{0}/{1}/{2}", parts[0], parts[1], path.TrimStart('~', '/'));

            return path;
        }

        #endregion Public Methods

    }
}