# Why Native Cells?
* Highly Customizable
* Increased Performance
* Support for Styles
    * Currently no support for Implicit Styles   

# Setup
* Available on NuGet: https://www.nuget.org/packages/Xam.Plugins.Forms.ExtendedCell/
* Install into your PCL project and Client projects.

In your Android, and Windows Phone projects call:

```
Xamarin.Forms.Init();//platform specific init
ExtendedTextCellRenderer.Init();
```

You must do this AFTER you call Xamarin.Forms.Init(). **If you are using LeftColumnWidth and RightColumnWidth make sure you use [GridUnitType.Star](http://iosapi.xamarin.com/index.aspx?link=T%3AXamarin.Forms.GridUnitType).**

# Usage

Listview :
```
<ListView ItemsSource="{Binding People}" RowHeight="60">
    <ListView.ItemTemplate>
      <DataTemplate>
        <abstractions:ExtendedTextCell LeftText="{Binding FirstName}" LeftTextColor="White" LeftTextFont="26"
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
          <abstractions:ExtendedTextCell BackgroundColor="White"
                                      LeftText="Left Text Large" LeftTextColor="Black"
                                      LeftDetail="Left Detail Italic" LeftDetailColor="Black"
                                      RightText="Right Text Micro" RightTextColor="Black"
                                      RightDetail="Right Detail Bold" RightDetailColor="Black" />
        </TableSection>
   </TableView>
```

For a detailed example clone the repo and take a look at the Sample App.

# Screenshots

![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/Droid_TwoColumnCell_Listview.png)
![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/Droid_TwoColumnCell_TableView1.png)
![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/Droid_TwoColumnCell_TableView2.png)

![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/WP_TwoColumnCell_Listview.png)
![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/WP_TwoColumnCell_TableView1.png)
![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/WP_TwoColumnCell_TableView2.png)

# License
Licensed under main repo license
