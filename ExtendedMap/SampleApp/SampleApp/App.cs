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


        View CreateView()
        {
            var _mapGrid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection {
					new RowDefinition (), new RowDefinition ()
				},
                ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					}
				},
                RowSpacing = 0
            };

            _mapGrid.Children.Add(new ContentView{BackgroundColor = Color.Yellow},0,0);
            _mapGrid.Children.Add(new ContentView{BackgroundColor = Color.Blue},0,1);


            const double collapsedMapHeight = 0.37;
            const double expandedMapHeight = 0.86;
            const double expandedFooterHeight = 0.63;

            //_minimizedFooterY = _pageHeight * expandedMapHeight;
            //_expandedFooterY = _pageHeight * collapsedMapHeight;

            //var footerHeight = height * expandedFooterHeight;

            _mapGrid.RowDefinitions[0].Height = new GridLength(528);
            _mapGrid.RowDefinitions[1].Height = new GridLength(327);

            //Device.OnPlatform(WinPhone: () =>
            //{
            //    //The rows need to be added in this order for win phone for the footer to display on top of the map
            //    _mapGrid.Children.Add(_extendedMap, 0, 0);
            //    _mapGrid.Children.Add(CreateFooter(footerHeight), 0, 1);
            //}, Android: () =>
            //{
            //    _mapGrid.Children.Add(_extendedMap, 0, 0);
            //    _mapGrid.Children.Add(CreateFooter(footerHeight), 0, 1);
            //});

            var tapGestureRecognizer = new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Debug.WriteLine("Footer tapped");
                })
            };

            tapGestureRecognizer.Tapped += (sender, args) =>
            {
                Debug.WriteLine("Footer tapped");
            };
            //tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "TapCommand");
            _mapGrid.Children[1].GestureRecognizers.Add(tapGestureRecognizer);

            return _mapGrid;
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
