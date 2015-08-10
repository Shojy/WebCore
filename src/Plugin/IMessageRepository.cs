#region Header
// <copyright company="Italik Ltd." file="IMessageRepository.cs">
// Copyright (c) 2015 Italik Ltd. All Rights Reserved.
// </copyright>
// <summary>
// IMessageRepository.cs is a part of the project Plugin. 
// </summary>
// <author>Joshua Moon</author>
#endregion
namespace Plugin
{
    /// <summary>
    /// Test plugin repository
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        /// Gets a message
        /// </summary>
        string Message { get; }
    }
}