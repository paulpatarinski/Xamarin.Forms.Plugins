using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using CoreLocation;
using ExtendedMap.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using ExtendedMap.Forms.Plugin.iOS;
using ExtendedMap.Forms.Plugin.iOS.Models;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof (ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof (ExtendedMapRenderer))]

namespace ExtendedMap.Forms.Plugin.iOS
{
  /// <summary>
  ///   ExtendedMap Renderer
  /// </summary>
  public class ExtendedMapRenderer : MapRenderer
  {
    public static void Init()
    {
    }

    #region private properties

    private ExtendedMapAnnotation _previouslySelectedNativePin;
    private ExtendedPin _previouslySelectedPin { get; set; }

    private MKMapView _nativeMapView
    {
      get { return Control as MKMapView; }
    }

    private Abstractions.ExtendedMap _customMap
    {
      get { return Element as Abstractions.ExtendedMap; }
    }

    private CustomMapContentView _customMapContentView
    {
      get { return _customMap.Parent.Parent as CustomMapContentView; }
    }

    #endregion private properties
  
    protected override void OnElementChanged(ElementChangedEventArgs<View> e)
    {
      base.OnElementChanged(e);

      _nativeMapView.Delegate = new MapDelegate();
      _customMap.CustomPins.CollectionChanged += HandleCollectionChanged;
    }

    //todo implement map center
    //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    //{
    //  if (e.PropertyName.Equals(Abstractions.ExtendedMap.CenterOnPositionProperty.PropertyName) ||
    //      e.PropertyName.Equals(Abstractions.ExtendedMap.CameraFocusYOffsetProperty.PropertyName))
    //  {
    //    CenterOnLocation(new LatLng(_customMap.CenterOnPosition.Latitude, _customMap.CenterOnPosition.Longitude),
    //      _customMap.CameraFocusYOffset);
    //  }
    //}

    private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        var pin = e.NewItems[0] as ExtendedPin;
        AddPin(pin);
      }
    }

    private void AddPin(ExtendedPin formsPin)
    {
      var nativePin =
        new ExtendedMapAnnotation(new CLLocationCoordinate2D(formsPin.Position.Latitude, formsPin.Position.Longitude),
          formsPin.Label, formsPin.Address, formsPin.PinIcon);

      nativePin.Clicked += HandleAnnotationClick;

      _nativeMapView.AddAnnotation(nativePin);
    }

    private void HandleAnnotationClick(object sender, ExtendedMapAnnotation e)
    {
//			ResetPrevioslySelectedMarker ();

//			var currentMarker = e.Marker;
//
//			currentMarker.SetIcon (BitmapDescriptorFactory.DefaultMarker ());

      _customMap.SelectedPinAddress = e.Subtitle;

      if (_customMapContentView.FooterMode == FooterMode.Hidden)
      {
        _customMapContentView.FooterMode = FooterMode.Minimized;
      }

      _previouslySelectedPin = _customMap.SelectedPin;
      _previouslySelectedNativePin = e;
    }
  }
}