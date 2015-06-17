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

Use RoundedBoxView instead of a regular BoxView :

```
  <abstractions:RoundedBoxView Style="{StaticResource RoundedBoxViewStyle}" CornerRadius="10" />
```

For a detailed example clone the repo and take a look at the Sample App.

# Screenshots

![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/Driod_RoundedBoxView.png)
![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/WP_RoundedBoxView.png)


# License
Licensed under main repo license
