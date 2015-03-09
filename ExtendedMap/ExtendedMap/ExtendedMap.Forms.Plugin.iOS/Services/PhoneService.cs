using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using ExtendedMap.Forms.Plugin.Abstractions.Services;
using ExtendedMap.Forms.Plugin.iOS.Services;
using Foundation;
using MessageUI;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneService))]
namespace ExtendedMap.Forms.Plugin.iOS.Services
{
  public class PhoneService : IPhoneService
  {
    public void OpenBrowser(string url)
    {
      throw new NotImplementedException();
    }

    public void DialNumber(string number, string name)
    {
      throw new NotImplementedException();
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

    public void LaunchNavigationAsync(NavigationModel navigationModel)
    {
      throw new NotImplementedException();
    }
  }
}