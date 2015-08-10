// <copyright company="Joshua Moon" file="HooksHandler.cs">
//     Copyright (c) 2015 Joshua Moon All Rights Reserved.
// </copyright>
// <summary>
// HooksHandler.cs is a part of the project Core.Plugins.Api.Hooks.Communications.
// </summary>
// <author>Joshua Moon</author>
// <license>
// This software may be modified and distributed under the terms of the MIT license. See the LICENSE
// file for details.
// </license>

namespace Core.Plugins.Api.Hooks.Communications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Provides methods for running and finding hooks in plugins.
    /// </summary>
    public static class HooksHandler
    {
        #region Private Fields

        /// <summary>
        /// Storage field for <see cref="Hooks" />.
        /// </summary>
        private static HooksCache _hooks;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the cache of discovered hook implementations.
        /// </summary>
        public static HooksCache Hooks
        {
            get
            {
                return _hooks ?? (_hooks = new HooksCache());
            }

            set
            {
                _hooks = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Registers all valid hooks from all loaded assemblies.
        /// </summary>
        public static void RegisterHooks()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                RegisterHooks(assembly);
            }
        }

        /// <summary>
        /// Registers all hooks in the provided assembly.
        /// </summary>
        /// <param name="assembly"><see cref="Assembly" /> to load hooks from.</param>
        public static void RegisterHooks(Assembly assembly)
        {
            foreach (var type in Hooks.Keys)
            {
                var hooks = assembly.GetTypes().Where(t => t.IsAssignableFrom(type) && !t.IsInterface && !t.IsAbstract);

                foreach (var hook in hooks.Where(t => !Hooks[type].Contains(t)))
                {
                    Hooks[type].Add(hook);
                }
            }
        }

        /// <summary>
        /// Runs a hook within a defined group.
        /// </summary>
        /// <typeparam name="THookType">Interface containing the hook to run.</typeparam>
        /// <param name="hookName">Name of the hook to be executed within plugins.</param>
        /// <param name="hookParams">
        /// Object data to pass into the hook method called. If the hook being called has
        /// reference-type parameters (e.g. ref or out), these values may be updated.
        /// </param>
        /// <returns>
        /// A list of objects returned by any hooked methods. The object may be null if the hook had
        /// a void return type.
        /// </returns>
        public static IEnumerable<object> RunHooks<THookType>(string hookName, params object[] hookParams)
            where THookType : class, IHook
        {
            var results = new List<object>();

            foreach (var hook in Hooks[typeof(THookType)])
            {
                var implementor = Activator.CreateInstance(hook);
                try
                {
                    var method = hook.GetMethod(
                        hookName,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    results.Add(method.Invoke(implementor, hookParams));
                }
                catch (ArgumentException ex)
                {
                    throw new ArgumentOutOfRangeException("Specified method does not exist on hook.", ex);
                }
            }

            return results;
        }

        /// <summary>
        /// Scans all loaded assemblies for interfaces that represent hooks. To represent a hook, an
        /// interface must extend <seealso cref="IHook" />.
        /// </summary>
        public static void ScanForHookTypes()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                ScanForHookTypes(assembly);
            }
        }

        /// <summary>
        /// Scans an assembly for interfaces that represent hooks. To represent a hook, an interface
        /// must extend <seealso cref="IHook" /> .
        /// </summary>
        /// <param name="assembly">The <see cref="Assembly" /> to scan through.</param>
        public static void ScanForHookTypes(Assembly assembly)
        {
            var type = typeof(IHook);
            var hookGroups = assembly.GetTypes().Where(t => type.IsAssignableFrom(t) && t.IsInterface);

            foreach (var group in hookGroups.Where(t => !Hooks.ContainsKey(t)))
            {
                Hooks.Add(group, new List<Type>());
            }
        }

        #endregion Public Methods
    }
}