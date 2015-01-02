using Android.App;
using Android.Content.PM;
using Android.OS;
using SVG.Forms.Plugin.Droid;
using Xamarin.Forms.Platform.Android;
using XamSvg;

namespace PluginSampleApp.Droid
{
    [Activity(Label = "PluginSampleApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

