using CoreLocation;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using ExtendedMap.Forms.Plugin.Abstractions.Services;
using ExtendedMap.Forms.Plugin.iOS.Services;
using Foundation;
using MapKit;
using MessageUI;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneService))]
namespace ExtendedMap.Forms.Plugin.iOS.Services
{
  /// <summary>
  /// Most of the implementations are from Xamarin Forms Labs
  /// https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/src/Platform/XLabs.Platform.iOS/Services/PhoneService.cs
  /// 
  /// </summary>
  public class PhoneService : IPhoneService
  {
    public void OpenBrowser(string url)
    {
      UIApplication.SharedApplication.OpenUrl(new NSUrl(url));
    }

    public void DialNumber(string number, string name)
    {
      UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + number));
    }
   
    public void ShareText(string text)
    {
      if (MFMessageComposeViewController.CanSendText)
      {
        var smsController = new MFMessageComposeViewController { Body = text};
        smsController.Finished += (sender, e) => smsController.DismissViewController(true, null);
        UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(smsController, true, null);
      }
    }

    /// <summary>
    /// Starts the Native Map Navigation
    /// Implementation from https://github.com/jamesmontemagno/Xamarin.Plugins/tree/master/ExternalMaps
    /// </summary>
    /// <param name="navigationModel"></param>
    public void LaunchNavigationAsync(NavigationModel navigationModel)
    {
      var mapItem =
        new MKMapItem(new MKPlacemark(new CLLocationCoordinate2D(navigationModel.Latitude, navigationModel.Longitude),
          new MKPlacemarkAddress{Street = navigationModel.DestinationAddress})) {Name = navigationModel.DestinationName};

      var launchOptions =
         new MKLaunchOptions
        {
          DirectionsMode =  MKDirectionsMode.Driving
        };

      var mapItems = new[] { mapItem };

      MKMapItem.OpenMaps(mapItems, launchOptions);
    }
  }
}