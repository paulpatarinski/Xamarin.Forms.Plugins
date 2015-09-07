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

Styles : 

- App.xaml : 
```
<Style x:Key="DefaultStyle" TargetType="abstractions:ExtendedTextCell">
  <Setter Property="BackgroundColor" Value="{StaticResource Black}"/>
  
  <Setter Property="LeftTextColor" Value="{StaticResource White}"/>
  <Setter Property="LeftTextFont" Value="{StaticResource Large}"/>

  <Setter Property="RightTextColor" Value="{StaticResource White}"/>
  <Setter Property="RightTextFont" Value="{StaticResource Large}"/>

  <Setter Property="LeftDetailColor" Value="{StaticResource Gray}"/>
  <Setter Property="LeftDetailFont" Value="{StaticResource Medium}"/>
  
  <Setter Property="RightDetailColor" Value="{StaticResource Gray}"/>
  <Setter Property="RightDetailFont" Value="{StaticResource Medium}"/>

</Style>
      
<!-- Cell Level Styles--> 
<Style x:Key="CellWithThickness" BasedOn="{StaticResource DefaultStyle}" TargetType="abstractions:ExtendedTextCell">
  <Setter Property="Thickness" >
    <Setter.Value>
      <Thickness>50,50,50,50</Thickness>
    </Setter.Value>
  </Setter>
</Style>
```
- Style Usage
```
<abstractions:ExtendedTextCell Style="{StaticResource CellWithThickness}"
                                LeftText="Cell With Thickness Specified" />
```

For a detailed example clone the repo and take a look at the Sample App.

# Screenshots

![ScreenShot](https://raw.githubusercontent.com/paulpatarinski/Xamarin.Forms.Plugins/master/SampleApp/Images/Screenshots/ExtendedTextCell_All.png)

# License
Licensed under main repo license
