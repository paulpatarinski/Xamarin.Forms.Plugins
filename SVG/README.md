# Why SVG?
[![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/WhySVG.PNG)](http://youtu.be/wlFVIIstKmA)

# Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.Svg/
* Install into your PCL project and Client projects.

In your Android,iOS and Windows Phone projects call:

```
Xamarin.Forms.Init();//platform specific init
SvgImageRenderer.Init();
```

You must do this AFTER you call Xamarin.Forms.Init();

# Usage
Instead of using an Image Control simply use a SvgImage instead!

### You MUST :

- Set Height and Width
- Set Build Action to Embedded Resource for your svg files 
- SvgPath to {Project}.{Folder}.{FileName}.{Extension}
- SvgAssembly to the assembly containing the file
- For Win Phone make sure you include a XAML file equivalent of the SVG with the root element being a Viewbox
 - Example : If you have Sample.svg also add Sample.xaml under the same folder of the svg.(No need to specify anything else as long as the names match)	

Code Usage :
```
new SvgImage { 
		SvgPath = "PluginSampleApp.Images.hipster.svg",
		SvgAssembly = typeof(App).GetTypeInfo().Assembly, 
		HeightRequest = 100,
		WidthRequest = 100
		};
```

Xaml Usage : 

```
  <abstractions:SvgImage Grid.Row="0" Grid.Column="0" SvgAssembly="{Binding SvgAssembly}" SvgPath="{Binding CoolMaskSvgPath}" HeightRequest="50" WidthRequest="50" BackgroundColor="White" HorizontalOptions="Center" VerticalOptions="Center"/>
```

In the example my SVG file is located under the Images folder in the PluginSampleApp project. The SvgAssembly is a reference to the assembly containing the svg/xaml file.

# Where to get SVG/XAML?
Win Phone does not support SVGs by default and there are no good SVG to Win Phone XAML libraries. Diederik Krols has a [really nice post](http://blogs.u2u.be/diederik/post/2012/07/26/Transforming-SVG-graphics-to-XAML-Metro-Icons.aspx) on how to convert SVG to Metro XAML. Check out the [nounproject](http://thenounproject.com/) for some royalty free SVGs.

# Screenshots

![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/SVG.JPG)

# License
Licensed under main repo license
