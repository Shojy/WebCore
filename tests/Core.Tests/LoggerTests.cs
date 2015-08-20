#region Header
// <copyright company="Joshua Moon" file="LoggerTests.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// LoggerTests.cs is a part of the project Core.Tests. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion
namespace Core.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using Ninject.Extensions.Logging;

    [TestClass]
    public class LoggerTests
    {
        private Logger _logger;

        private Mock<ILogger> _mock;

        [TestInitialize]
        public void Init()
        {
            this._mock = new Mock<ILogger>();
            this._logger = new Logger(this._mock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this._mock = null;
            this._logger = null;
        }

        [TestMethod]
        public void Warn_TakesMessageAndCallsMock_ShouldPassMessageToMock()
        {
            var message = "Warning Message";

            this._logger.Warn(message);

            this._mock.Verify(m => m.Warn(message), Times.Once);
        }

        [TestMethod]
        public void Warn_TakesMessageAndExceptionCallsMock_ShouldPassBothToMock()
        {
            var message = "Warning message!";
            var exception = new SystemException(message);

            this._logger.Warn(message, exception);

            this._mock.Verify(m => m.Warn(message, exception), Times.Once);
        }
    }
}