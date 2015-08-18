#region Header

// <copyright company="Joshua Moon" file="HomeControllerTests.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// HomeControllerTests.cs is a part of the project Core.Tests.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core.Tests.Controllers
{
    using System.Web.Mvc;

    using Core.Controllers;
    using Core.Plugins.Api;
    

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;
    

    /// <summary>
    /// Provides tests for <see cref="HomeController" />.
    /// </summary>
    [TestClass]
    public class HomeControllerTests
    {
        #region Private Fields

        /// <summary>
        /// Controller under tests.
        /// </summary>
        private HomeController _controller;

        private Mock<ILogger> _mockLogger;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Cleans up after each test has been run.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            this._controller.Dispose();
            this._controller = null;
            this._mockLogger = null;
        }

        /// <summary>
        /// Tests that the Index action returns the correct view and message.
        /// </summary>
        [TestMethod]
        public void IndexActionReturnsIndexView()
        {
            var view = (ViewResult)this._controller.Index();

            Assert.AreNotEqual(null, view);
            Assert.AreEqual("Index", view.ViewName);
            Assert.AreEqual("Hello from home!", view.ViewBag.Message);
        }

        /// <summary>
        /// Initializes the tests.
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this._mockLogger = new Mock<ILogger>();
            this._controller = new HomeController(this._mockLogger.Object);
        }

        #endregion Public Methods
    }
}