# Plugins for Xamarin Forms

# What is this?
This is my main repo for all Xamarin Forms Plugins that I have or will be publishing. These PCL plugins will allow you to add rich cross platform functionality to Xamarin.Forms.

# Current Plugins for Xamarin Forms

Controls:
* **[SVG](https://github.com/paulpatarinski/Xamarin.Forms.Plugins/tree/master/SVG)** for Xamarin.Forms
 * Win Phone / Android
* **[Extended Cells](https://github.com/paulpatarinski/Xamarin.Forms.Plugins/tree/master/ExtendedCells)** for Xamarin.Forms
 * Win Phone / Android / iOS

# Repo structure :
Sample App : 
 * A solution demonstrating all the plugins in a single app
  * Uses nuget to reference the plugins (Testing that the nuget packages work)
  
Plugin : 
 * Each plugin has its own Sample App allowing you to test the plugin as you are developing it
  * Plugin projects are referenced directly 
 * Each Platform has a project containing the Platform Specific Code
 * All Platform Projects reference the PCL Project (contains the Control implementation)
  
Each plugin has its own Readme with more details.

# Contributors
The repo structure is courtesy of

* [jamesmontemagno](https://github.com/jamesmontemagno) For the Xamarin Forms Plugin repo template and VS solution template
* [conceptdev](https://github.com/conceptdev) For [Forms2Native](https://github.com/xamarin/xamarin-forms-samples/tree/master/Forms2Native), which inspired [Extended Cells](https://github.com/paulpatarinski/Xamarin.Forms.Plugins/tree/master/ExtendedCells) 
 

# License
Licensed under MIT see License file
