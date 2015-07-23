using Android.App;
using Android.Content.PM;
using Android.OS;
using RoundedBoxView.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace SampleApp.Droid
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

			RoundedBoxView.Forms.Plugin.Droid.RoundedBoxViewRenderer.Init();

            LoadApplication(new App());
        }
    }
}

