using System;
using System.Device.Location;
using System.Threading.Tasks;
using ExtendedMap.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.WindowsPhone.Services;
using Microsoft.Phone.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneService))]
namespace ExtendedMap.Forms.Plugin.WindowsPhone.Services
{
    public class PhoneService : IPhoneService
    {
        public void OpenBrowser(string url)
        {
            var webBrowserTask = new WebBrowserTask {Uri = new Uri(url, UriKind.Absolute)};

            webBrowserTask.Show();
        }

        public void DialNumber(string number, string name)
        {
            var phoneCallTask = new PhoneCallTask {PhoneNumber = number, DisplayName = name};

            phoneCallTask.Show();
        }

        public void ShareText(string text)
        {
            var smsComposeTask = new SmsComposeTask
            {
                Body = text
            };

            smsComposeTask.Show();
        }

        public void LaunchNavigationAsync(NavigationModel navigationModel)
        {
            var mapsDirectionsTask = new MapsDirectionsTask();

            var destinationGeolocation = new GeoCoordinate(navigationModel.Latitude, navigationModel.Longitude);
            var destinationMapLocation = new LabeledMapLocation(navigationModel.DestinationName, destinationGeolocation);
            
            mapsDirectionsTask.End = destinationMapLocation;

            mapsDirectionsTask.Show();
        }
    }
}
