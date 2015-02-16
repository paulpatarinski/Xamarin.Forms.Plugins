using Android.Content;
using Android.Net;
using Android.Telephony;
using ExtendedMap.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using ExtendedMap.Forms.Plugin.Abstractions.Services;
using ExtendedMap.Forms.Plugin.Droid.Extensions;
using ExtendedMap.Forms.Plugin.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneService))]
namespace ExtendedMap.Forms.Plugin.Droid.Services
{
  public class PhoneService : IPhoneService
  {
      /// <summary>
      /// Opens native dialog to dial the specified number.
      /// </summary>
      /// <param name="number">Number to dial.</param>
      /// <param name="name"></param>
      public void DialNumber(string number, string name)
    {
      number.StartActivity(new Intent(Intent.ActionDial, Uri.Parse("tel:" + number)));
    }

    public void OpenBrowser(string url)
    {
      Uri uri = Uri.Parse(url);
      Intent intent = new Intent(Intent.ActionView);
      intent.SetData(uri);

      Intent chooser = Intent.CreateChooser(intent, "Open with");

      this.StartActivity(chooser);
    }

    public void SendSMS(string to, string body)
    {
      SmsManager.Default.SendTextMessage(to, null, body, null, null);
    }

    public void ShareText(string text)
    {
      Intent sendIntent = new Intent();
      sendIntent.SetAction(Intent.ActionSend);
      sendIntent.PutExtra(Intent.ExtraText, text);
      sendIntent.SetType("text/plain");
      this.StartActivity(sendIntent);
    }

    public void LaunchMap(string address)
    {
      var geoUri = Uri.Parse(string.Format("geo:0,0?q={0}", address));

      StartActivity(geoUri);
    }

    public void LaunchNavigationAsync(NavigationModel navigationModel)
    {
      var uri = Uri.Parse("google.navigation:q=" + navigationModel.DestinationAddress);

      StartActivity(uri);
    }

    private void StartActivity(Uri uri)
    {
      var intent = new Intent(Intent.ActionView, uri);
      this.StartActivity(intent);
    }
  }
}
