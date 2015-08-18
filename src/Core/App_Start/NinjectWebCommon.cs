#region Header

// <copyright company="Joshua Moon" file="NinjectWebCommon.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// NinjectWebCommon.cs is a part of the project Core.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

using Core;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectWebCommon), "Stop")]

namespace Core
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Compilation;

    using Core.Plugins.Api;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    /// <summary>
    /// Ninject startup methods
    /// </summary>
    public static class NinjectWebCommon
    {
        #region Private Fields

        /// <summary>
        /// Ninject bootstrapper for setting up the application
        /// </summary>
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Find all plugin directories and register assemblies from each of them.
            var path = // Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "bin");
                Reference.AbsolutePluginsDirectory;
            var plugins = Directory.EnumerateDirectories(path);

            foreach (var bin in plugins.Select(plugin => Path.Combine(path, plugin, "bin")))
            {
                kernel.Bind(a => a.FromAssembliesInPath(bin).SelectAllClasses().BindDefaultInterface());
                var files = Directory.EnumerateFiles(bin, "*.dll");
                foreach (var file in files)
                {
                    try
                    {
                        var assembly = Assembly.UnsafeLoadFrom(file);
                        AppDomain.CurrentDomain.Load(assembly.GetName());
                        BuildManager.AddReferencedAssembly(assembly);
                        kernel.Bind(a => a.From(assembly).SelectAllClasses().BindDefaultInterface());
                    }
                    catch (BadImageFormatException)
                    {
                        // Skip over any incompatible assemblies.
                        continue;
                    }
                    catch (FileLoadException)
                    {
                        continue;
                    }
                }
            }
        }

        #endregion Private Methods
    }
}