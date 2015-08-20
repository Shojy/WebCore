// <copyright company="Joshua Moon" file="Reference.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// Reference.cs is a part of the project Core.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

namespace Core.Plugins.Api
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Web;

    /// <summary>
    /// Provides reference to a number of system values.
    /// </summary>
    /// <remarks>
    /// Storage fields are used to cache the values from the configuration file to avoid the need for multiple reads.
    /// </remarks>
    public static class Reference
    {
        #region Private Fields

        /// <summary>
        /// Storage field for <see cref="DefaultTheme" />.
        /// </summary>
        private static string _defaultTheme;

        /// <summary>
        /// Storage field for <see cref="PluginsDirectory" />.
        /// </summary>
        private static string _pluginsDirectory;

        /// <summary>
        /// Sotrage field for <see cref="ThemesDirectory" />.
        /// </summary>
        private static string _themesDirectory;

        private static string _activeTheme;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the directory name of the currently active theme.
        /// </summary>
        public static string ActiveTheme
        {
            get
            {
                return _activeTheme ?? DefaultTheme;
            }
            set
            {
                _activeTheme = value;
            }
        }
        /// <summary>
        /// Gets the absolute path to the plugins root directory.
        /// </summary>
        public static string AbsolutePluginsDirectory
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, PluginsDirectory);
            }
        }

        /// <summary>
        /// Gets the directory of the default theme.
        /// </summary>
        public static string DefaultTheme
        {
            get
            {
                return _defaultTheme ?? (_defaultTheme = ConfigurationManager.AppSettings["DefaultTheme"]);
            }
        }

        /// <summary>
        /// Gets the path to the plugins root directory, relative to the project root.
        /// </summary>
        public static string PluginsDirectory
        {
            get
            {
                return _pluginsDirectory ?? (_pluginsDirectory = ConfigurationManager.AppSettings["PluginsDirectory"]);
            }
        }

        /// <summary>
        /// Gets the path to the themes root directory, relative to the project root.
        /// </summary>
        public static string ThemesDirectory
        {
            get
            {
                return _themesDirectory ?? (_themesDirectory = ConfigurationManager.AppSettings["ThemesDirectory"]);
            }
        }

        /// <summary>
        /// Gets the virtual path of the plugins root directory.
        /// </summary>
        public static string VirtualPluginsDirectory
        {
            get
            {
                return VirtualPathUtility.Combine(AppDomain.CurrentDomain.BaseDirectory, PluginsDirectory);
            }
        }

        #endregion Public Properties
    }
}