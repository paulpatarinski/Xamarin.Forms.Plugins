using Android.App;
using Android.Content.PM;
using Android.OS;
using ExtendedCells.Forms.Plugin.Android;
using SVG.Forms.Plugin.Droid;
using Xamarin.Forms.Platform.Android;

namespace PluginSampleApp.Droid
{
    [Activity(Label = "PluginSampleApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            SvgImageRenderer.Init();
            TwoColumnCellRenderer.Init();

            LoadApplication(new App());
        }
    }
}

