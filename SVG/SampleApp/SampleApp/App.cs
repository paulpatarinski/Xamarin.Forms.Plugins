using SVG.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace SampleApp
{
    public class App : Application
    {
        public App()
        {
            //Get SVGs from http://thenounproject.com/
            var svgPaths = new List<string>
            {
                "SampleApp.Images.CoolGuy.svg",
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

            MainPage = new ContentPage { Content = horizontalScrollView };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
