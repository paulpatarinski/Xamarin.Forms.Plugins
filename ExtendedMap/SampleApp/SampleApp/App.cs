using System.Diagnostics;
using ExtendedMap.Forms.Plugin.Abstractions;
using PluginSampleApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SampleApp
{
    public class App : Application
    {
        public App()
        {
            BindingContext = new ExtendedMapViewModel();

            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            grid.Children.Add(CreateMapContentView(), 0, 0);

            MainPage = new ContentPage { Content = grid };
        }
      
        View CreateMapContentView()
        {
            //Coordinates for the starting point of the map
            const double latitude = 41.788081;
            const double longitude = -87.831573;

            var location = new Position(latitude, longitude);

            var _map = new global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap(MapSpan.FromCenterAndRadius(location, Distance.FromMiles(15))) { IsShowingUser = true };

            _map.StyleId = "CustomMap";

            _map.BindingContext = BindingContext;

            _map.SetBinding<ExtendedMapViewModel>(global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap.CustomPinsProperty, x => x.SamplePins);

            var createMapContentView = new CustomMapContentView(_map);

            return createMapContentView;
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
