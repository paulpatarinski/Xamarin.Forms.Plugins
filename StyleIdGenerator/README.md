# Why Native Cells?
* Type Safety
* Speed
* Compiler time errors

#How it works?
The startFolder path is scanned for all xaml files containing usages of StyleId="%value%". A struct is then created for each file, allowing you to reference the ids via a strongly typed class (StyleIds).

# Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.StyleIdGenerator
* Install into your UI Test project.
* Open the StyleIdGenerator_Config.tt in the Generator Folder 
* Point the startFolder to the root solution path. 
 
Example : 
```
var startFolder = @"C:\Xamarin.Forms.Plugins\StyleIdGenerator";     
```

# Usage
Update the startFolder variable in the StyleIdGenerator_Config.tt to point to the root of your solution. Kicking off the generation by saving the file. Use the StyleIds struct to access the ids.

```
[Test]
public void LabelPage2_ShouldBeSelectable()
{
    var lblPage2 = _app.Query(StyleIds.Page2.lblPage2);

    Assert.IsNotNull(lblPage2);
    Assert.IsTrue(lblPage2.Any());
}
```

For a detailed example clone the repo and take a look at the UITests project.

# License
Licensed under main repo license
