# Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.RoundedBoxView/
* Install into your PCL project and Client projects.

In your Android, iOS and Windows Phone projects call:

```
Xamarin.Forms.Init();//platform specific init
RoundedBoxViewRenderer.Init();
```

You must do this AFTER you call Xamarin.Forms.Init(). 

# Usage

Add this line of code to your Xaml File

...
xmlns:abstractions="clr-namespace:RoundedBoxView.Forms.Plugin.Abstractions;assembly=RoundedBoxView.Forms.Plugin.Abstractions"
...

Use RoundedBoxView instead of a regular BoxView :

```
   <abstractions:RoundedBoxView BackgroundColor="Red" HeightRequest="100" WidthRequest="100"  
   BorderColor="Blue" CornerRadius="50" BorderThickness="20" />
```

For a detailed example clone the repo and take a look at the Sample App.

# Screenshots

![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/Droid_RoundedBoxView.png)
![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/WP_RoundedBoxView.png)
![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/iOS_RoundedBoxView.PNG)


# License
Licensed under main repo license
