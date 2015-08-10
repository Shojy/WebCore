#region Header

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

#endregion Header

namespace Core
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Web;

    /// <summary>
    /// Provides reference to a number of system values.
    /// </summary>
    public static class Reference
    {
        #region Private Fields

        /// <summary>
        /// Storage field for <seealso cref="PluginsDirectory" />
        /// </summary>
        private static string _pluginsDirectory;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets the absolute path to the plugins root directory
        /// </summary>
        public static string AbsolutePluginsDirectory
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, PluginsDirectory);
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