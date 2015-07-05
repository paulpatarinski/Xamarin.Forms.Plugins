using System.Collections.Specialized;
using System.ComponentModel;
using Android.App;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using ExtendedMap.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using ExtendedMap.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof (ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof (ExtendedMapRenderer))]

namespace ExtendedMap.Forms.Plugin.Droid
{
  public class ExtendedMapRenderer : MapRenderer
  {
    public static void Init()
    {
    }

    #region private properties

    private Marker _previouslySelectedNativePin { get; set; }

    private ExtendedPin _previouslySelectedPin { get; set; }

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

      var androidMapView = (MapView) Control;

      _customMap.CustomPins.CollectionChanged += HandleCollectionChanged;

      androidMapView.Map.Clear();

      androidMapView.Map.MarkerClick += HandleMarkerClick;
      androidMapView.Map.MapClick += HandleMapClick;
      androidMapView.Map.MyLocationEnabled = _customMap.IsShowingUser;

      //The footer overlays the zoom controls
      androidMapView.Map.UiSettings.ZoomControlsEnabled = false;

      LoadPins();
    }

    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (e.PropertyName.Equals(Abstractions.ExtendedMap.CenterOnPositionProperty.PropertyName) ||
          e.PropertyName.Equals(Abstractions.ExtendedMap.CameraFocusYOffsetProperty.PropertyName))
      {
        CenterOnLocation(new LatLng(_customMap.CenterOnPosition.Latitude, _customMap.CenterOnPosition.Longitude),
          _customMap.CameraFocusYOffset);
      }
    }

    private void AddPin(ExtendedPin formsPin)
    {
      var androidMapView = (MapView) Control;

      var markerWithIcon = new MarkerOptions();

      markerWithIcon.SetPosition(new LatLng(formsPin.Position.Latitude, formsPin.Position.Longitude));
      markerWithIcon.SetTitle(formsPin.Label);
      markerWithIcon.SetSnippet(formsPin.Address);

      if (!string.IsNullOrEmpty(formsPin.PinIcon))
      {
        markerWithIcon.InvokeIcon(BitmapDescriptorFactory.FromResource(GetResourceIdByName(formsPin.PinIcon)));
      }
      else
        markerWithIcon.InvokeIcon(BitmapDescriptorFactory.DefaultMarker());

      androidMapView.Map.AddMarker(markerWithIcon);
    }

    private void LoadPins()
    {
      var formsPins = _customMap.CustomPins;

      foreach (var formsPin in formsPins)
      {
        AddPin(formsPin);
      }
    }

    private void HandleCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        var pin = e.NewItems[0] as ExtendedPin;
        AddPin(pin);
      }
    }

    private void HandleMapClick(object sender, GoogleMap.MapClickEventArgs e)
    {
      _customMapContentView.Footer.FooterMode = FooterMode.Hidden;

      ResetPrevioslySelectedMarker();
    }

    private int GetResourceIdByName(string resourceName)
    {
      var resourceId = Resources.GetIdentifier(resourceName.ToLower(), "drawable", ((Activity) Context).PackageName);

      return resourceId;
    }

    private void ResetPrevioslySelectedMarker()
    {
      //todo : This should reset to the default icon for the pin (right now the icon is hard coded)
      if (_previouslySelectedNativePin != null && !string.IsNullOrEmpty(_previouslySelectedPin.PinIcon))
      {
        _previouslySelectedNativePin.SetIcon(
          BitmapDescriptorFactory.FromResource(GetResourceIdByName(_previouslySelectedPin.PinIcon)));
      }

      _previouslySelectedNativePin = null;
    }

    private void HandleMarkerClick(object sender, GoogleMap.MarkerClickEventArgs e)
    {
      ResetPrevioslySelectedMarker();

      var currentMarker = e.Marker;

      currentMarker.SetIcon(BitmapDescriptorFactory.DefaultMarker());

      _customMap.SelectedPinAddress = currentMarker.Snippet;

      if (_customMapContentView.Footer.FooterMode == FooterMode.Hidden)
      {
        _customMapContentView.Footer.FooterMode = FooterMode.Minimized;
      }

      _previouslySelectedPin = _customMap.SelectedPin;
      _previouslySelectedNativePin = currentMarker;
    }

    private void CenterOnLocation(LatLng location, int yOffset = 100)
    {
      var mapView = (MapView) Control;

      var projection = mapView.Map.Projection;

      var screenLocation = projection.ToScreenLocation(location);
      screenLocation.Y += yOffset;

      var offsetTarget = projection.FromScreenLocation(screenLocation);

      // Animate to the calculated lat/lng
      mapView.Map.AnimateCamera(CameraUpdateFactory.NewLatLng(offsetTarget));
    }
  }
}