#region Header

// <copyright company="Joshua Moon" file="CoreRazorViewEngine.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// CoreRazorViewEngine.cs is a part of the project Core.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Mvc;

    /// <summary>
    /// Represents a view engine that is used to render a web page that is capable of rendering
    /// pages for plugin-based views.
    /// </summary>
    public class CoreRazorViewEngine : RazorViewEngine
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreRazorViewEngine" /> class. Loads
        /// possible view locations to the ViewEngine, including plugin View folders.
        /// </summary>
        public CoreRazorViewEngine()
        {
            this.AreaMasterLocationFormats = new[]
                                             {
                                                 "~/" + Reference.PluginsDirectory + "/{2}/Views/{1}/{0}.cshtml",
                                                 "~/" + Reference.PluginsDirectory + "/{2}/Views/{1}/{0}.vbhtml",
                                                 "~/" + Reference.PluginsDirectory + "/{2}/Views/Shared/{0}.cshtml",
                                                 "~/" + Reference.PluginsDirectory + "/{2}/Views/Shared/{0}.vbhtml"
                                             };

            this.AreaPartialViewLocationFormats = new[]
                                                  {
                                                      "~/" + Reference.PluginsDirectory + "/{2}/Views/{1}/{0}.cshtml",
                                                      "~/" + Reference.PluginsDirectory + "/{2}/Views/{1}/{0}.vbhtml",
                                                      "~/" + Reference.PluginsDirectory + "/{2}/Views/Shared/{0}.cshtml",
                                                      "~/" + Reference.PluginsDirectory + "/{2}/Views/Shared/{0}.vbhtml"
                                                  };

            var areaViewAndPartialViewLocationFormats = new List<string>
                                                        {
                                                            "~/" + Reference.PluginsDirectory
                                                            + "/{2}/Views/{1}/{0}.cshtml",
                                                            "~/" + Reference.PluginsDirectory
                                                            + "/{2}/Views/{1}/{0}.vbhtml",
                                                            "~/" + Reference.PluginsDirectory
                                                            + "/{2}/Views/Shared/{0}.cshtml",
                                                            "~/" + Reference.PluginsDirectory
                                                            + "/{2}/Views/Shared/{0}.vbhtml"
                                                        };

            var partialViewLocationFormats = new List<string>
                                             {
                                                 "~/Views/{1}/{0}.cshtml",
                                                 "~/Views/{1}/{0}.vbhtml",
                                                 "~/Views/Shared/{0}.cshtml",
                                                 "~/Views/Shared/{0}.vbhtml"
                                             };

            var masterLocationFormats = new List<string>
                                        {
                                            "~/Views/{1}/{0}.cshtml",
                                            "~/Views/{1}/{0}.vbhtml",
                                            "~/Views/Shared/{0}.cshtml",
                                            "~/Views/Shared/{0}.vbhtml"
                                        };

            var paths = Directory.EnumerateDirectories(Reference.AbsolutePluginsDirectory);

            foreach (var path in paths)
            {
                var plugin = path.Substring(path.LastIndexOf('\\') + 1);

                masterLocationFormats.Add("~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/{1}/{0}.cshtml");
                masterLocationFormats.Add("~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/{1}/{0}.vbhtml");
                masterLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/Shared/{1}/{0}.cshtml");
                masterLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/Shared/{1}/{0}.vbhtml");

                partialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/{1}/{0}.cshtml");
                partialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/{1}/{0}.vbhtml");
                partialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/Shared/{0}.cshtml");
                partialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/Shared/{0}.vbhtml");

                areaViewAndPartialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/{1}/{0}.cshtml");
                areaViewAndPartialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Views/{1}/{0}.vbhtml");
                areaViewAndPartialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Areas/{2}/Views/{1}/{0}.cshtml");
                areaViewAndPartialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Areas/{2}/Views/{1}/{0}.vbhtml");
                areaViewAndPartialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Areas/{2}/Views/Shared/{0}.cshtml");
                areaViewAndPartialViewLocationFormats.Add(
                    "~/" + Reference.PluginsDirectory + "/" + plugin + "/Areas/{2}/Views/Shared/{0}.vbhtml");
            }

            this.ViewLocationFormats = partialViewLocationFormats.ToArray();
            this.MasterLocationFormats = masterLocationFormats.ToArray();
            this.PartialViewLocationFormats = partialViewLocationFormats.ToArray();
            this.AreaPartialViewLocationFormats = areaViewAndPartialViewLocationFormats.ToArray();
            this.AreaViewLocationFormats = areaViewAndPartialViewLocationFormats.ToArray();
        }

        #endregion Public Constructors
    }
}