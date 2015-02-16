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
            throw new NotImplementedException();
        }

        public void DialNumber(string number)
        {
            throw new NotImplementedException();
        }

        public void SendSMS(string to, string body)
        {
            throw new NotImplementedException();
        }

        public void ShareText(string text)
        {
            var smsComposeTask = new SmsComposeTask()
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
