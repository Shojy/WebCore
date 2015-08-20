#region Header
// <copyright company="Joshua Moon" file="Theme.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// Theme.cs is a part of the project Core.Plugins.Api. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion
namespace Core.Plugins.Api
{
    using System.Web.Configuration;

    /// <summary>
    /// Provides theme related methods for assisting with correct viewing.
    /// </summary>
    public static class Theme
    {
        /// <summary>
        /// Translates a theme-rooted virtual path to an application-rooted virtual path.
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

            // TODO: Add current theme detection
            var currentTheme = string.Empty;

            path = string.Format("~/{0}/{1}/{2}", Reference.ThemesDirectory, currentTheme, path.TrimStart('~', '/'));

            return path;
        }
    }
}