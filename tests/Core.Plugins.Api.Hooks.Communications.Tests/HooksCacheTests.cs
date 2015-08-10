#region Header

// <copyright company="Joshua Moon" file="HooksCacheTests.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// HooksCacheTests.cs is a part of the project Core.Plugins.Api.Hooks.Communications.Tests.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

#endregion Header

namespace Core.Plugins.Api.Hooks.Communications.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests for the <see cref="HooksCache" /> class.
    /// </summary>
    [TestClass]
    public class HooksCacheTests
    {
        #region Private Fields

        /// <summary>
        /// Class under test.
        /// </summary>
        private HooksCache _cache;

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Cleans up the tests after being run.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            this._cache = null;
        }

        /// <summary>
        /// Initializes the tests
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            this._cache = new HooksCache();
        }

        /// <summary>
        /// Tests that a key that does not previously exist in the cache creates a new, empty entry
        /// when accessed.
        /// </summary>
        [TestMethod]
        public void UnknownKeyReturnsEmptyList()
        {
            var key = typeof(IEnumerable);

            Assert.IsFalse(this._cache.ContainsKey(key));

            var value = this._cache[key];

            Assert.AreNotEqual(null, value);
            Assert.IsTrue(value.Count == 0);
            Assert.IsTrue(this._cache.ContainsKey(key));
        }

        /// <summary>
        /// Tests that values can be added using the Add method, and correctly retrieved via index.
        /// </summary>
        [TestMethod]
        public void ValuesCanBeAddedAndRetrievedTest()
        {
            var key = typeof(IEnumerable);
            var value = new List<Type>() { typeof(string), typeof(TestMethodAttribute) };

            this._cache.Add(key, value);

            Assert.AreEqual(value, this._cache[key]);
            Assert.AreSame(value, this._cache[key]);
        }

        /// <summary>
        /// Tests that a value can be added by a key that does not previously exist.
        /// </summary>
        [TestMethod]
        public void ValuesCanBeAddedByKey()
        {
            var key = typeof(IEnumerable);
            var value = new List<Type>() { typeof(string), typeof(TestMethodAttribute) };

            Assert.IsFalse(this._cache.ContainsKey(key));

            this._cache[key] = value;

            Assert.AreEqual(value, this._cache[key]);
            Assert.AreSame(value, this._cache[key]);
        }

        #endregion Public Methods
    }
}