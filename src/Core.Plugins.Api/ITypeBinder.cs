#region Header
// <copyright company="Joshua Moon" file="ITypeBinder.cs">
// Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// IBinder.cs is a part of the project Core.Plugins.Api. 
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms
// of the MIT license.  See the LICENSE file for details.
// </license>
#endregion
namespace Core.Plugins.Api
{
    /// <summary>
    /// Exposes methods for binding an interface to a target type.
    /// </summary>
    public interface ITypeBinder
    {
        /// <summary>
        /// Binds an interface to a target that will fulfill the requirements at resolution.
        /// </summary>
        /// <typeparam name="TInterface">The interface to be fulfilled.</typeparam>
        /// <typeparam name="TTarget">The type to fulfill this interface.</typeparam>
        /// <returns>This class instance for chaining methods.</returns>
        ITypeBinder Bind<TInterface, TTarget>();
    }
}