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

    /// <summary>
    ///     A wrapper for the log4net logging service
    /// </summary>
    public class Logger : ILogger
    {
        #region Private Fields

        /// <summary>
        ///     Internal log4net logger.
        /// </summary>
        private readonly Ninject.Extensions.Logging.ILogger _logger;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger"/> class.
        /// </summary>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public Logger(Ninject.Extensions.Logging.ILogger logger)
        {
            this._logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Creates a DEBUG level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        public void Debug(string message)
        {
            this._logger.Debug(message);
        }

        /// <summary>
        /// Creates a DEBUG level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        /// <param name="exception">
        /// Exception to log.
        /// </param>
        public void Debug(string message, Exception exception)
        {
            this._logger.DebugException(message, exception);
        }

        /// <summary>
        /// Creates an ERROR level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        public void Error(string message)
        {
            this._logger.Error(message);
        }

        /// <summary>
        /// Creates an ERROR level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        /// <param name="exception">
        /// Exception to log.
        /// </param>
        public void Error(string message, Exception exception)
        {
            this._logger.ErrorException(message, exception);
        }

        /// <summary>
        /// Creates a FATAL level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        public void Fatal(string message)
        {
            this._logger.Fatal(message);
        }

        /// <summary>
        /// Creates a FATAL level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        /// <param name="exception">
        /// Exception to log.
        /// </param>
        public void Fatal(string message, Exception exception)
        {
            this._logger.FatalException(message, exception);
        }

        /// <summary>
        /// Creates an INFO level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        public void Info(string message)
        {
            this._logger.Info(message);
        }

        /// <summary>
        /// Creates an INFO level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        /// <param name="exception">
        /// Exception to log.
        /// </param>
        public void Info(string message, Exception exception)
        {
            this._logger.InfoException(message, exception);
        }

        /// <summary>
        /// Creates a WARNING level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        public void Warn(string message)
        {
            this._logger.Warn(message);
        }

        /// <summary>
        /// Creates a WARNING level log.
        /// </summary>
        /// <param name="message">
        /// Message text to log.
        /// </param>
        /// <param name="exception">
        /// Exception to log.
        /// </param>
        public void Warn(string message, Exception exception)
        {
            this._logger.WarnException(message, exception);
        }

        #endregion Public Methods
    }
}