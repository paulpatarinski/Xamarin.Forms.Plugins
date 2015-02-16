using System;
using System.Collections.Specialized;
using System.Device.Location;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;
using Windows.Devices.Geolocation;
using ExtendedMap.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.WindowsPhone;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Maps.Toolkit;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Platform.WinPhone;
using Map = Microsoft.Phone.Maps.Controls.Map;
using Point = System.Windows.Point;

[assembly: ExportRenderer(typeof(global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof(ExtendedMapRenderer))]
namespace ExtendedMap.Forms.Plugin.WindowsPhone
{
    /// <summary>
    /// ExtendedMap Renderer
    /// </summary>
    public class ExtendedMapRenderer : ViewRenderer<global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap, Map>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }
        private Map _nativeMap;
        private ExtendedPin _selectedPin;
        private global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap _formsMap
        {
            get { return Element as global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap; }
        }

        private CustomMapContentView _customMapContentView
        {
            get { return _formsMap.Parent.Parent as CustomMapContentView; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<global::ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap> e)
        {
            base.OnElementChanged(e);

            if (_nativeMap == null)
            {
                //_formsMap.NavigationButton.Clicked += NavigationButtonOnClicked;
                //Center position Chicago
                const double latitude = 41.951692;
                const double longitude = -87.993720;

                _nativeMap = new Map { ZoomLevel = 9, Center = new GeoCoordinate(latitude, longitude) };
                //_nativeMap.Tap += NativeMapOnTap;
                _formsMap.CustomPins.CollectionChanged += CustomPinsOnCollectionChanged;
                this.SetNativeControl(_nativeMap);

                AddCurrentLocationToMap();

                foreach (var formsPin in _formsMap.CustomPins)
                {
                    AddFormsPinToNativeMap(formsPin);
                }
            }
        }

        private void AddFormsPinToNativeMap(ExtendedPin formsPin)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var nativePin = new Pushpin();
                nativePin.Tap += NativePinOnTap;

                var geoCoordinate = new GeoCoordinate(formsPin.Position.Latitude, formsPin.Position.Longitude);
                nativePin.GeoCoordinate = geoCoordinate;
                nativePin.Content = formsPin.Label + "\n" + formsPin.Address;

                var nativePinMapOverlay = new MapOverlay();
                nativePinMapOverlay.Content = nativePin;
                nativePinMapOverlay.GeoCoordinate = geoCoordinate;

                var mapLayer = new MapLayer();
                mapLayer.Add(nativePinMapOverlay);

                _nativeMap.Layers.Add(mapLayer);
                
            });
           
        }

        private void CustomPinsOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            switch (notifyCollectionChangedEventArgs.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    foreach (ExtendedPin newItem in notifyCollectionChangedEventArgs.NewItems)
                    {
                        AddFormsPinToNativeMap(newItem);
                    }
                    break;
                }

                case NotifyCollectionChangedAction.Remove:
                {
                    foreach (ExtendedPin formsPin in notifyCollectionChangedEventArgs.NewItems)
                    {
                        var nativePin = new Pushpin();
                        nativePin.Tap += NativePinOnTap;

                        var geoCoordinate = new GeoCoordinate(formsPin.Position.Latitude, formsPin.Position.Longitude);
                        nativePin.GeoCoordinate = geoCoordinate;
                        nativePin.Content = formsPin.Label + "\n" + formsPin.Address;

                        var nativePinMapOverlay = new MapOverlay();
                        nativePinMapOverlay.Content = nativePin;
                        nativePinMapOverlay.GeoCoordinate = geoCoordinate;

                        var mapLayer = new MapLayer();
                        mapLayer.Add(nativePinMapOverlay);


                        var nativePinIndex = _nativeMap.Layers.IndexOf(mapLayer);
                        _nativeMap.Layers.RemoveAt(nativePinIndex);
                    }
                    break;
                }
                case NotifyCollectionChangedAction.Reset:
                {
                    _nativeMap.Layers.Clear();
                    break;
                }
            }
        }

        private async void NavigationButtonOnClicked(object sender, EventArgs eventArgs)
        {
            var uri = new Uri(string.Format("ms-drive-to:?destination.latitude={0}&destination.longitude={1}&destination.address={2}&destination.name={3}", _selectedPin.Position.Latitude,
               _selectedPin.Position.Longitude, _selectedPin.Address, _selectedPin.Label));

            await Windows.System.Launcher.LaunchUriAsync(uri);
        }

        private void NativePinOnTap(object sender, System.Windows.Input.GestureEventArgs gestureEventArgs)
        {
            var nativePin = (Pushpin)sender;

            var contentArray = nativePin.Content.ToString().Split('\n');

            var label = contentArray[0];
            var description = contentArray[1];

            _selectedPin = new ExtendedPin
            {
                Label = label,
                Address = description,
                Position = new Position(nativePin.GeoCoordinate.Latitude, nativePin.GeoCoordinate.Longitude)
            };

            _formsMap.SelectedPinAddress= description;

            if (_customMapContentView.FooterMode == FooterMode.Hidden)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _customMapContentView.FooterMode = FooterMode.Minimized;
                });
            }
        }

        private async Task AddCurrentLocationToMap()
        {
            var myGeolocator = new Geolocator();
            var myGeoposition = await myGeolocator.GetGeopositionAsync();
            var myGeocoordinate = myGeoposition.Coordinate;
            var myGeoCoordinate =
                CoordinateConverter.ConvertGeocoordinate(myGeocoordinate);
            var myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(System.Windows.Media.Colors.Blue);
            myCircle.Height = 20;
            myCircle.Width = 20;
            myCircle.Opacity = 50;

            var myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = myGeoCoordinate;

            // Create a MapLayer to contain the MapOverlay.
            var myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);

            _nativeMap.Layers.Add(myLocationLayer);
        }
    }
    public static class CoordinateConverter
    {
        public static GeoCoordinate ConvertGeocoordinate(Geocoordinate geocoordinate)
        {
            return new GeoCoordinate
                (
                geocoordinate.Latitude,
                geocoordinate.Longitude,
                geocoordinate.Altitude ?? Double.NaN,
                geocoordinate.Accuracy,
                geocoordinate.AltitudeAccuracy ?? Double.NaN,
                geocoordinate.Speed ?? Double.NaN,
                geocoordinate.Heading ?? Double.NaN
                );
        }
    }
}
