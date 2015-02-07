using System.Collections.Generic;
using System.Reflection;
using SVG.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace SampleApp.Pages
{
  public  class ViaCode : ContentPage
  {
    public ViaCode()
    {
      Title = "Via Code";

      //Get SVGs from http://thenounproject.com/
      var svgPaths = new List<string>
            {
                "SampleApp.Images.CoolMask.svg",
                "SampleApp.Images.Elvis.svg",
                "SampleApp.Images.tiger.svg",
            };

      var grid = new Grid
      {
        RowDefinitions = new RowDefinitionCollection(),
        ColumnDefinitions = new ColumnDefinitionCollection()
      };

      for (var rowIndex = 0; rowIndex < svgPaths.Count; rowIndex++)
      {
        var svgPath = svgPaths[rowIndex];

        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

        for (var columnIndex = 0; columnIndex <= 4; columnIndex++)
        {
          grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

          //IMPORTANT Make sure you set both SvgPath and SvgAssembly
          var svgImage = new SvgImage
          {
            SvgPath = svgPath,
            SvgAssembly = typeof(App).GetTypeInfo().Assembly,
            HeightRequest = columnIndex * 50,
            WidthRequest = columnIndex * 50,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            BackgroundColor = Color.White
          };

          grid.Children.Add(svgImage, columnIndex, rowIndex);
        }
      }

      var verticalScrollView = new ScrollView { Orientation = ScrollOrientation.Vertical, Content = grid };

      var horizontalScrollView = new ScrollView
      {
        Orientation = ScrollOrientation.Horizontal,
        Content = verticalScrollView,
      };

      Content = horizontalScrollView;
    }
  }
}
