# Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.KeyboardOverlap/
* Add to your iOS project.

In your iOS project call:

```
Xamarin.Forms.Init();//platform specific init
KeyboardOverlapRenderer.Init ();
```

You must do this AFTER you call Xamarin.Forms.Init(). 

# Usage

No need for you to do anything other then initialize the plugin. The keyboard will no longer overlap your Controls!!!

For a detailed example clone the repo and take a look at the Sample App.

# How it works? 

1. Subscibe to keyboard Show/Dismiss events
2. On Keyboard Show
  1. Find the Control, which activated the keyboard. (FirstResponder)
  2. Determine if keyboard overlaps the Control
  3. Calculate how far you need to shift the Page Up
  4. Shift the Page Up
3. On Keyboard Dismiss 
  1. If Page was shifted up, shift the Page Down.

# Screenshots

![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/KeyboardOverlap1.png)
![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/KeyboardOverlap2.png)

# License
Licensed under main repo license
