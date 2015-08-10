#region Header

// <copyright company="Joshua Moon" file="CoreControllerFactory.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// CoreControllerFactory.cs is a part of the project Core.
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
    using System.Net;
    using System.Reflection;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Ninject;
    using Ninject.Extensions.Conventions;

    /// <summary>
    /// Represents the controller factory for loading plugin-based controllers
    /// </summary>
    public class CoreControllerFactory : DefaultControllerFactory
    {
        #region Private Fields

        /// <summary>
        /// Ninject kernel used for instanciating controllers
        /// </summary>
        private readonly IKernel _ninjectKernel;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CoreControllerFactory" /> class.
        /// </summary>
        public CoreControllerFactory()
        {
            this._ninjectKernel = new StandardKernel();
            this.AddBindings();
        }

        #endregion Public Constructors

        #region Protected Methods

        /// <summary>
        /// The get controller instance.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        /// <param name="controllerType">The controller type.</param>
        /// <exception cref="HttpException">
        /// <seealso cref="controllerType" /> is null -or- Controller matching
        /// <seealso cref="controllerType" /> was not found.
        /// </exception>
        /// <returns>The <see cref="IController" />.</returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // Null controller type will never resolve.
            if (null == controllerType)
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Bad controller type requested.");
            }

            var controller = this._ninjectKernel.Get(controllerType) as IController;

            // No atching controller was found.
            if (null == controller)
            {
                throw new HttpException((int)HttpStatusCode.NotFound, "Controller could not be found.");
            }

            return controller;
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Adds default bindings to the ninject kernel
        /// </summary>
        private void AddBindings()
        {
            var assemblies = BuildManager.GetReferencedAssemblies();

            foreach (Assembly assembly in assemblies)
            {
                this._ninjectKernel.Bind(a => a.From(assembly).SelectAllClasses().BindDefaultInterface());
            }
        }

        #endregion Private Methods
    }
}