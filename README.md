# WebCore #
WebCore is a plugin-based ASP.NET MVC website.  

The idea is that functionality is almost entirely removed from the Core, and instead added by plugins. By keeping the plugins simple and isolated, it helps to promote better coding practice, and each becomes easier to test and reuse.

## Installing Plugins ##
Installing a plugin is as simple as dropping it into the plugins folder. Your plugin should contain at least a `manifest.xml` file, otherwise exactly what you include is up to you. It is recommedned that you follow good practice. Features like Dependency Injection are handled for you, you just need to include a constructor taking an interface in your controllers. However, there are some conventions you should follow.

Within the plugin folder (`Plugins/PluginName`), you should...

 - `*.dll` and other binaries should be located in a `bin/` folder
 - If used, Controllers should be kept within a `Controllers/` folder, and if used, you should include an `AreaRegistration` implementation to register the routes.
 - If used, Views should be kept within a `Views/` folder, and follow normal ASP.NET MVC conventions.
 - If your plugin exposes a Web API, you should ensure it's route begins with `api/`, followed by your plugin's prefix.

### Sample Area Registration ###

```csharp
public class PluginAreaRegistration : AreaRegistration
{
    public override string AreaName
    {
        get { return "Plugin"; }
    }

    public override void RegisterArea(AreaRegistrationContext context)
    {
		var apiRoute = context.Routes.MapHttpRoute(
			name: "Plugin_API",
			routeTemplate: "api/plugin/{controller}/{id}",
			defaults: new { id = RouteParameter.Optional });
		apiRoute.DataTokens["Namespaces"] = new string[] {"Plugin.Controllers"};

        context.MapRoute(
            name: "Plugin", 
            url: "plugin/{controller}/{action}/{id}", 
            defaults: new { controller = "Plugin", action = "Index", id = UrlParameter.Optional },
            namespaces: new[] { "Plugin.Controllers" });
    } 
}
```

## Advanced Use ##
 - [Hooks](docs/hooks.md) <br/>
  *Hooks are used to extend functionality either of the core system, or Plugins that publish hooks.*
 - [Bindings](docs/bindings.md) <br/> 
  *Binding extensions can be used to control or modify the Dependency Injector settings, and map new types to interfaces used by the Core and Plugins.*