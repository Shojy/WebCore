# Plugin Hooks #
[Back to Contents](../README.md)

Hooks are used to extend functionality or run code at various points. The Core system hosts a range of hooks, and plugins can also expose their own.

To use a hook, all you need to do is implement the relevant interface, and have the class as `public`. The Core will handle the discovery, registration and calling of your methods for you. Hooks are grouped by relevance into interfaces. You can implement this directly, however we recommend inheriting from the provided abstract classes and overriding just the methods you require. This will give you cleaner code, and remove the need to implement unrequired hooks.

Hooks are found in the `Core.Plugins.Api` package under the `Core.Plugins.Api.Hooks` namespace.

## Consumable Hooks ##

### Application Start and Stop Hooks ###
These hooks are called at points during application strat and shutdown.

Hooks are defined in the `IApplicationStartHooks` interface, and the `ApplicationStartHooks` abstract class.

#### `RegisterBundles( BundleCollection )` ####
This hook is called during the bundle registration process. This can be used to add script and style bundles that should be used by the Core.

```csharp
public class AppStart : ApplicationStartHooks
{
	public override void RegisterBundles(BundleCollection bundles) 
	{
	    bundles.Add(
	    	new StyleBundle("~/Content/my_plugin_css")
	    		.Include("~/Content/bootstrap.css", Plugin.ToAppVirtualPath("~/Content/plugin.css")));
	}
}
```

### Navigation Hooks ###
These hooks are called when determining the various navigation elements.

## Defining Hooks within a Plugin ##
Along with using hooks, a plugin can define its own for others to comsume. It is recommended that any hooks defined are declared in a seperate, distributable `.dll` file or project.

### Defining a Hook ###
To create a hook, you will need to create an interface that extends `Core.Plugins.Api.Hooks.IHook`. Hook methods should be void, and if you require values to be returned to you, these should be via a passed reference object. It is a good idea to accompany your interface with an abstract class with default implementations so that a user may select only the hooks they desire to implement.

Example of a hook for consumption by another plugin.

```csharp
public interface IMyHooks : IHook
{
	void MyHookMethod(int number);
}

public abstract class MyHooks : IMyHooks
{
	public virtual void MyHookMethod(int number) {}
}
```
### Calling a Defined Hook ###
Now that we have a hook defined for other plugins to use, you can easily run it using our handler. You will need the `Core.Plugins.Api.Hooks.Communications` package for this.

```csharp
var results = HooksHander.RunHooks<IMyHooks>("MyHookMethod", 123);
```

The return value is a list of objects returned from the hook method, (or `null`s if the hook returns void).