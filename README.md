# Peernet SDK
__Peernet SDK__ (Peernet.SDK) is a __Class Library__ project targetting .NET 5.0. The SDK is devided into few parts. One part is __Models__ which is set of plugin interfaces, domain and presentation models.  
Presentation models are used among presentation part of the Peernet Browser. They define objects living in the User Interface.  
Domain models are objects representing structures returned from the backend. They are mainly needed for the second part of the SDK, which is _Client_.  
__Client__ is set of APIs for Backend communication. Single _PeernetClient_ object gathers all functionalities in one place.  
Last part of the SDK are __Common__ objects. These are objects shared within the system, e.g. _ISettingsManager_ which gives access to application settings.

### Usage
Peernet SDK solution builds into a single library __Peernet.SDK.dll__. 
To develop .NET solution for the Peernet system all you need to do is to reference the library (See [details](https://docs.microsoft.com/en-us/visualstudio/ide/managing-references-in-a-project?view=vs-2022)).
```
<ItemGroup>
	<Reference Include="Peernet.SDK">
		<HintPath>..\..\Peernet.SDK.dll</HintPath>
	</Reference>
</ItemGroup>
```

Peernet SDK is used in [Peernet Browser](https://github.com/PeernetOfficial/Browser) as well as [Peernet Plugins](https://github.com/PeernetOfficial/BrowserPlugins).

If you are using IoC container in your solution you can use _RegisterPeernetClients_ extension method from _Peernet.SDK.Client.Extensions_ namespace.
```
Action<HttpResponseMessage, string> onRequestFailure =
    (response, details) => notificationsManager?.Notifications.Add(
        new($"Unexpected response status code: {response.StatusCode}", details, Severity.Error));
services.RegisterPeernetClients(() => settings.ApiUrl, settings.ApiKey, onRequestFailure);
```

Otherwise you should construct new _PeernetClient_ object for backend interactions.

# Plugins Template
__Plugins Template__ (Peernet.Browser.Plugins.Template) is a __Class Library__  project targetting .NET 5.0 with __WPF__ features enabled.
The project essentials are:
- Peernet.SDK dependency
- Plugin interfaces implementation

The template project consist of few sample classes:
- _SamplePlugin_ implementing __IPlugin__ interface.  
- _SampleService_ implementing __IPlayButtonPlug__.
- _SampleGenericWindow_ and _SampleWindow_ which demonstrate some use cases and are optional.
- _SampleGenericViewModel_ and _SampleViewModel_ which are ViewModels for Windows mentioned above whereas _SampleGenericViewModel_ differs from a regular ViewModelBase descendants with its ability to pass a parameter to a ViewModel.

To find out how particular interfaces are utilized within UI check the [Peernet Browser](https://github.com/PeernetOfficial/Browser) documentation.

## Plugin development
To develop your own plugin its recommanded to use a copy of the _Peernet.Browser.Plugins.Template_ solution. You can either modify and extend sample classes accordingly to your needs
or clean up the template and start from scratch.
If you decide to develop the plugin from the beginning remember about essentials.  
__Peernet.SDK__ needs to be compatible with the version of Peernet Browser to which you would like to plug in. 
Differences in Models or Client incompatible with current Backend version may result in runtime errors.  
Your plugin's most important class is the one implementing __IPlugin__ interface, without it Peernet Browser won't load your plugin.  
The purpose of __IPlugin__ interface is to allow the plugin to access the IoC Container to register all required services and pluggable interfaces implementation.  
The __IPlayButtonPlug__ interface is one of pluggable interfaces for the Peernet Browser customization.
It is the interface for the _Play_ button available on Search & Explore & Directory Tab data grid rows. It exposes _Execute_ method which is invoked whenever the button is clicked.
