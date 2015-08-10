#region Header
// <copyright company="Italik Ltd." file="MessageRepository.cs">
// Copyright (c) 2015 Italik Ltd. All Rights Reserved.
// </copyright>
// <summary>
// MessageRepository.cs is a part of the project Plugin. 
// </summary>
// <author>Joshua Moon</author>
#endregion
namespace Plugin
{
    /// <summary>
    /// Message repository implementation
    /// </summary>
    public class MessageRepository : IMessageRepository
    {
        /// <summary>
        /// Gets a string
        /// </summary>
        public string Message
        {
            get
            {
                return "Hello World!";
            }
        }
    }
}