# Why Native Cells?
* Highly Customizable
* Increased Performance

# Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.ExtendedCell/
* Install into your PCL project and Client projects.

In your Android, and Windows Phone projects call:

```
Xamarin.Forms.Init();//platform specific init
TwoColumnCellRenderer.Init();
```

You must do this AFTER you call Xamarin.Forms.Init();

# Usage

Listview :
```
<ListView ItemsSource="{Binding People}" RowHeight="60">
    <ListView.ItemTemplate>
      <DataTemplate>
        <abstractions:TwoColumnCell LeftText="{Binding FirstName}" LeftTextColor="White" LeftTextFont="26"
                                    LeftDetail="{Binding PhoneNumber}" LeftDetailColor="Silver" LeftDetailFont="Italic"
                                    RightText="{Binding LastName}" RightTextColor="Fuchsia" RightTextFont="26"
                                    RightDetail="{Binding Address}" RightDetailColor="Pink" />
      </DataTemplate>
    </ListView.ItemTemplate>
  </ListView>
```

TableView : 

```
   <TableView>
        <TableSection Title="Background Color">
          <abstractions:TwoColumnCell BackgroundColor="White"
                                      LeftText="Left Text Large" LeftTextColor="Black"
                                      LeftDetail="Left Detail Italic" LeftDetailColor="Black"
                                      RightText="Right Text Micro" RightTextColor="Black"
                                      RightDetail="Right Detail Bold" RightDetailColor="Black" />
        </TableSection>
   </TableView>
```

For a detailed example clone the repo and take a look at the Sample App.

# Screenshots

![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/SVG.JPG)

# License
Licensed under main repo license
