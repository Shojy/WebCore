#region Header
// <copyright company="Joshua Moon" file="Logger.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// Logger.cs is a part of the project Core. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion
namespace Core
{
    using System;

    using Core.Plugins.Api;

    using log4net;

    using Microsoft.Ajax.Utilities;

    /// <summary>
    /// A wrapper for the log4net logging service
    /// </summary>
    public class Logger : ILogger
    {
        private ILog _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public Logger(ILog logger)
        {
            this._logger = logger;
        }

        /// <summary>
        /// Creates a WARNING level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        public void Warn(object message)
        {
            this._logger.Warn(message);
        }

        /// <summary>
        /// Creates a WARNING level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        /// <param name="exception">Exception to log.</param>
        public void Warn(object message, Exception exception)
        {
            this._logger.Warn(message, exception);
        }

        /// <summary>
        /// Creates a WARNING level formatted log.
        /// </summary>
        /// <param name="format">Format string.</param>
        /// <param name="args">Args to be inserted.</param>
        public void WarnFormat(string format, params object[] args)
        {
            this._logger.WarnFormat(format, args);
        }
    }
}