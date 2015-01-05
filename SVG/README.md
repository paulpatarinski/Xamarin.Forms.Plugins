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

You **MUST** : 
- Set Height and Width
- Set Build Action to Embedded Resource 
- SvgPath to {Project}.{Folder}.{FileName}.{Extension}
- SvgAssembly to the assembly containing the file
- For Win Phone make sure you include a XAML file corresponding to the SVG with the root element being a Viewbox

Here is a sample:
```
new SvgImage { 
		SvgPath = "PluginSampleApp.Images.hipster.svg",
		SvgAssembly = typeof(App).GetTypeInfo().Assembly, 
		HeightRequest = 100,
		WidthRequest = 100
		};
```

In the example my SVG file is located under the Images folder in the PluginSampleApp project. The SvgAssembly is a reference to the assembly containing the svg/xaml file.

# Where to get SVG/XAML?
Win Phone does not support SVGs by default and there are no good SVG to Win Phone XAML libraries. Therefore the easiest way to get an SVG and it's XAML equivalent is download [Metro Studio](http://www.syncfusion.com/downloads/metrostudio).This software will give you a large selection of SVGs with the ability to export in Metro XAML format ALL FOR FREE.

# License
Licensed under main repo license
