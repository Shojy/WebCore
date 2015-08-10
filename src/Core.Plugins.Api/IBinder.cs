#region Header
// <copyright company="Joshua Moon" file="IBinder.cs">
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
    /// Exposes a method for adding custom dependency bindings.
    /// </summary>
    public interface IBinder
    {
        void Bind(ITypeBinder typeBinder);
    }
}