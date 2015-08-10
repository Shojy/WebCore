#region Header

// <copyright company="Joshua Moon" file="HomeController.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// HomeController.cs is a part of the project Core.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        #region Public Methods

        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>The <see cref="ActionResult" />.</returns>
        public ActionResult Index()
        {
            this.ViewBag.Message = "Hello from home!";
            return this.View("Index");
        }

        #endregion Public Methods
    }
}