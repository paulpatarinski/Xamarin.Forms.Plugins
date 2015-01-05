# SVG Image Control Plugin for Xamarin.Forms

# Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.Svg/
* Install into your PCL project and Client projects.

In your Android, and Windows Phone projects call:

```
Xamarin.Forms.Init();//platform specific init
SvgImageRenderer.Init();
```

You must do this AFTER you call Xamarin.Forms.Init();

# Usage
Instead of using an Image simply use a SvgImage instead!

You **MUST** set the WidthRequest, HeightRequest, SvgPath and SvgAssemblyProperties. Here is a sample:
```
new SvgImage { 
		SvgPath = "PluginSampleApp.Images.hipster.svg",
		SvgAssembly = typeof(App).GetTypeInfo().Assembly, 
		HeightRequest = 100,
		WidthRequest = 100
		};
```

In the example my svg source is located under the Images folder in the PluginSampleApp project.

# License
Licensed under main repo license