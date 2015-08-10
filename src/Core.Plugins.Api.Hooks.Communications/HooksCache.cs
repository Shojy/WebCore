#region Header

// <copyright company="Joshua Moon" file="HooksCache.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// HooksCache.cs is a part of the project Core.Plugins.Api.Hooks.Communications.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core.Plugins.Api.Hooks.Communications
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a collection of identified hook implementing types.
    /// </summary>
    public sealed class HooksCache : Dictionary<Type, List<Type>>
    {
        #region Public Indexers

        /// <summary>
        /// Gets or sets the value associated with a specified key. If the key does not exist when
        /// setting, it creates a new key and sets the value to the newly created key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        /// The <see cref="IEnumerable{Type}" /> containing the hooks registered for the given
        /// parent type.
        /// </returns>
        public new List<Type> this[Type key]
        {
            get
            {
                if (this.ContainsKey(key))
                {
                    return base[key];
                }

                return this[key] = new List<Type>();
            }

            set
            {
                if (!this.ContainsKey(key))
                {
                    this.Add(key, null);
                }

                base[key] = value;
            }
        }

        #endregion Public Indexers
    }
}