#region Header
// <copyright company="Joshua Moon" file="ILogger.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// ILogger.cs is a part of the project Core.Plugins.Api. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion
namespace Core.Plugins.Api
{
    using System;

    /// <summary>
    /// Represents a collection of methods for logging events at various levels.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Creates a WARNING level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        void Warn(string message);

        /// <summary>
        /// Creates a WARNING level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        /// <param name="exception">Exception to log.</param>
        void Warn(string message, Exception exception);

        /// <summary>
        /// Creates an INFO level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        void Info(string message);

        /// <summary>
        /// Creates an INFO level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        /// <param name="exception">Exception to log.</param>        
        void Info(string message, Exception exception);

        /// <summary>
        /// Creates an ERROR level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        void Error(string message);

        /// <summary>
        /// Creates an ERROR level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        /// <param name="exception">Exception to log.</param>        
        void Error(string message, Exception exception);

        /// <summary>
        /// Creates a DEBUG level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        void Debug(string message);

        /// <summary>
        /// Creates a DEBUG level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        /// <param name="exception">Exception to log.</param>        
        void Debug(string message, Exception exception);

        /// <summary>
        /// Creates a FATAL level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        void Fatal(string message);

        /// <summary>
        /// Creates a FATAL level log.
        /// </summary>
        /// <param name="message">Message text to log.</param>
        /// <param name="exception">Exception to log.</param>        
        void Fatal(string message, Exception exception);
    }
}