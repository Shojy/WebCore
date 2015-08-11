// <copyright company="Joshua Moon" file="TestHExtensions.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// TestHExtensions.cs is a part of the project Core.Plugins.Api.Hooks.Communications.Tests.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

namespace Core.Plugins.Api.Hooks.Communications.Tests
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Provides utility methods forassiting with tests.
    /// </summary>
    public static class TestExtensions
    {
        #region Public Methods

        /// <summary>
        /// The set field.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="fieldName">The field.</param>
        /// <param name="value">The value.</param>
        public static void SetField(this object obj, string fieldName, object value)
        {
            var type = obj.GetType();
            var x = type.GetFields();
            var field = type.GetField(
                fieldName,
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            if (null != field)
            {
                field.SetValue(obj, value);
            }
            else
            {
                throw new ArgumentOutOfRangeException("fieldName", "Field does not exist.");
            }
        }

        /// <summary>
        /// Sets the property of an object, irrespective of normal accessibility of the setter.
        /// </summary>
        /// <param name="obj">Object containing the property to set.</param>
        /// <param name="property">String name of the property to set. This is case-sensitive.</param>
        /// <param name="value">
        /// The value to assign to the propery. The type should be expected by the property.
        /// </param>
        /// <param name="index">Optional index for indexed properties.</param>
        public static void SetProperty(this object obj, string property, object value, object[] index = null)
        {
            var type = obj.GetType();

            if (obj is Type)
            {
                type = (Type)obj;
                obj = null;
            }

            type.GetProperty(property, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
                .SetValue(obj, value, index);
        }

        #endregion Public Methods
    }
}