using ExtendedMap.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using ExtendedMap.Forms.Plugin.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.Maps.iOS;
using MapKit;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using CoreLocation;
using System.Collections.Specialized;

[assembly: ExportRenderer(typeof(ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof(ExtendedMapRenderer))]
namespace ExtendedMap.Forms.Plugin.iOS
{
    /// <summary>
    /// ExtendedMap Renderer
    /// </summary>
    public class ExtendedMapRenderer : MapRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

		private ExtendedPin _previouslySelectedPin { get; set; }

		ExtendedMapAnnotation _previouslySelectedNativePin;

		private Abstractions.ExtendedMap _customMap {
			get { return Element as Abstractions.ExtendedMap; }
		}

		private MKMapView _nativeMapView {
			get { return Control as MKMapView; }
		}

		private CustomMapContentView _customMapContentView {
			get { return _customMap.Parent.Parent as CustomMapContentView; }
		}

		protected override void OnElementChanged (ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged (e);

			_nativeMapView.Delegate = new MapDelegate ();
			_customMap.CustomPins.CollectionChanged += HandleCollectionChanged;

		}

		void HandleCollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Add) {
				var pin = e.NewItems [0] as ExtendedPin;
				AddPin (pin);
			}
		}

		void AddPin (ExtendedPin formsPin)
		{
			var nativePin = new ExtendedMapAnnotation (new CLLocationCoordinate2D (formsPin.Position.Latitude, formsPin.Position.Longitude), formsPin.Label, formsPin.Address);

			nativePin.Clicked += HandleAnnotationClick;

			_nativeMapView.AddAnnotation (nativePin);

//			var androidMapView = (MapView)Control;
//
//			var markerWithIcon = new MarkerOptions ();
//
//			markerWithIcon.SetPosition (new LatLng (formsPin.Position.Latitude, formsPin.Position.Longitude));
//			markerWithIcon.SetTitle (formsPin.Label);
//			markerWithIcon.SetSnippet (formsPin.Address);
//
//			if (!string.IsNullOrEmpty (formsPin.PinIcon))
//			{
//				markerWithIcon.InvokeIcon(BitmapDescriptorFactory.FromResource(GetResourceIdByName(formsPin.PinIcon)));
//			}
//			else
//				markerWithIcon.InvokeIcon (BitmapDescriptorFactory.DefaultMarker ());
//
//			androidMapView.Map.AddMarker (markerWithIcon);
		}

		private void HandleAnnotationClick (object sender, ExtendedMapAnnotation e)
		{
//			ResetPrevioslySelectedMarker ();

//			var currentMarker = e.Marker;
//
//			currentMarker.SetIcon (BitmapDescriptorFactory.DefaultMarker ());

			_customMap.SelectedPinAddress = e.Subtitle;

			if (_customMapContentView.FooterMode == FooterMode.Hidden) {
				_customMapContentView.FooterMode = FooterMode.Minimized;
			}

			_previouslySelectedPin = _customMap.SelectedPin;
			_previouslySelectedNativePin = e;
		}
    }
}
