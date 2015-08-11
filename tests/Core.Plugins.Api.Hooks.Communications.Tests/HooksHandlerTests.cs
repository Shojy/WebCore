// <copyright company="Joshua Moon" file="HooksHandlerTests.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// HooksHandlerTests.cs is a part of the project Core.Plugins.Api.Hooks.Communications.Tests.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

namespace Core.Plugins.Api.Hooks.Communications.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// The hooks handler tests.
    /// </summary>
    [TestClass]
    public class HooksHandlerTests
    {
        private Mock<HooksCache> _mockCache;

        /// <summary>
        /// Initializes the tests
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this._mockCache = new Mock<HooksCache>();

            typeof(HooksHandler).SetProperty("Hooks", this._mockCache.Object);
        }

        /// <summary>
        /// Cleans up the tests after being run.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            typeof(HooksHandler).SetProperty("Hooks", null);
            this._mockCache = null;
        }

        [TestMethod]
        public void TestExtensions_MockIsAssignedCorrectly()
        {
            Assert.AreSame(this._mockCache.Object, HooksHandler.Hooks);
        }
    }
}