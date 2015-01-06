using System;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMap.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof(ExtendedMapRenderer))]

namespace ExtendedMap.Forms.Plugin.Droid
{
	public class ExtendedMapRenderer : MapRenderer
	{
        public static void Init() { }

		private bool _isDrawnDone;

		private Marker _previouslySelectedMarker { get; set; }

		private ExtendedPin _previouslySelectedPin { get; set; }

		private Abstractions.ExtendedMap _customMap {
            get { return Element as ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap; }
		}

		private CustomMapContentView _customMapContentView {
			get { return _customMap.Parent.Parent as CustomMapContentView; }
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			var androidMapView = (MapView)Control;

			if (e.PropertyName.Equals ("CenterOnPosition")) {
				CenterOnLocation (new LatLng (_customMap.CenterOnPosition.Latitude, _customMap.CenterOnPosition.Longitude),
					_customMap.CameraFocusYOffset);
			}

			if (e.PropertyName.Equals ("IsShowingUser")) {
				androidMapView.Map.MyLocationEnabled = _customMap.IsShowingUser;
			}

			if (e.PropertyName.Equals ("VisibleRegion") && !_isDrawnDone) {
				androidMapView.Map.Clear ();

				androidMapView.Map.MarkerClick += HandleMarkerClick;
				androidMapView.Map.MapClick += HandleMapClick;
				androidMapView.Map.MyLocationEnabled = _customMap.IsShowingUser;

				//The footer overlays the zoom controls
				androidMapView.Map.UiSettings.ZoomControlsEnabled = false;

				_customMap.CustomPins.CollectionChanged += HandleCollectionChanged;

				ResetMap ();
				LoadPins ();

				_isDrawnDone = true;
			}
		}

		void ResetMap ()
		{
			var androidMapView = (MapView)Control;

			androidMapView.Map.Clear ();

			_previouslySelectedPin = null;
			_previouslySelectedMarker = null;

			_customMapContentView.FooterMode = FooterMode.Hidden;
		}


		void AddPin (ExtendedPin formsPin)
		{
			var androidMapView = (MapView)Control;

			var markerWithIcon = new MarkerOptions ();

			markerWithIcon.SetPosition (new LatLng (formsPin.Position.Latitude, formsPin.Position.Longitude));
			markerWithIcon.SetTitle (formsPin.Label);
			markerWithIcon.SetSnippet (formsPin.Address);

			if (!string.IsNullOrEmpty (formsPin.PinIcon))
				markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromAsset (String.Format ("{0}.png", formsPin.PinIcon)));
			else
				markerWithIcon.InvokeIcon (BitmapDescriptorFactory.DefaultMarker ());

			androidMapView.Map.AddMarker (markerWithIcon);
		}

		void LoadPins ()
		{
			var androidMapView = (MapView)Control;

			var formsPins = _customMap.CustomPins;

			foreach (var formsPin in formsPins) {
				var markerWithIcon = new MarkerOptions ();

				markerWithIcon.SetPosition (new LatLng (formsPin.Position.Latitude, formsPin.Position.Longitude));
				markerWithIcon.SetTitle (formsPin.Label);
				markerWithIcon.SetSnippet (formsPin.Address);

				if (!string.IsNullOrEmpty (formsPin.PinIcon))
					markerWithIcon.InvokeIcon (BitmapDescriptorFactory.FromAsset (String.Format ("{0}.png", formsPin.PinIcon)));
				else
					markerWithIcon.InvokeIcon (BitmapDescriptorFactory.DefaultMarker ());

				androidMapView.Map.AddMarker (markerWithIcon);
			}
		}

		void HandleCollectionChanged (object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset) {
				ResetMap ();
			}
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
				var pin = e.NewItems [0] as ExtendedPin;
				AddPin (pin);
			}
		}

		private void HandleMapClick (object sender, GoogleMap.MapClickEventArgs e)
		{
			_customMapContentView.FooterMode = FooterMode.Hidden;

			ResetPrevioslySelectedMarker ();
		}

		private void ResetPrevioslySelectedMarker ()
		{
			//todo : This should reset to the default icon for the pin (right now the icon is hard coded)
			if (_previouslySelectedMarker != null && !string.IsNullOrEmpty (_previouslySelectedPin.PinIcon)) {
				_previouslySelectedMarker.SetIcon (
					BitmapDescriptorFactory.FromAsset (String.Format ("{0}.png", _previouslySelectedPin.PinIcon)));
			}

			_previouslySelectedMarker = null;
		}

		private void HandleMarkerClick (object sender, GoogleMap.MarkerClickEventArgs e)
		{
			ResetPrevioslySelectedMarker ();

			var currentMarker = e.P0;

//			CenterOnLocation (currentMarker.Position, _customMap.CameraFocusYOffset);

			currentMarker.SetIcon (BitmapDescriptorFactory.DefaultMarker ());

			_customMap.SelectedPinAddress = currentMarker.Snippet;

			if (_customMapContentView.FooterMode == FooterMode.Hidden) {
				_customMapContentView.FooterMode = FooterMode.Minimized;
			}

			_previouslySelectedPin = _customMap.SelectedPin;
			_previouslySelectedMarker = currentMarker;
		}

		private void CenterOnLocation (LatLng location, int yOffset = 100)
		{
			var mapView = (MapView)Control;

			var projection = mapView.Map.Projection;

			var screenLocation = projection.ToScreenLocation (location);
			screenLocation.Y += yOffset;

			var offsetTarget = projection.FromScreenLocation (screenLocation);

			// Animate to the calculated lat/lng
			mapView.Map.AnimateCamera (CameraUpdateFactory.NewLatLng (offsetTarget));
		}
	}
}