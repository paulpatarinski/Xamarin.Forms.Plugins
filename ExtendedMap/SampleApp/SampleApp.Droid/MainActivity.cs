using Android.App;
using Android.Content.PM;
using Android.OS;
using ExtendedMap.Forms.Plugin.Droid;
using Xamarin;

namespace SampleApp.Droid
{
    [Activity(Label = "SampleApp", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            FormsMaps.Init(this,bundle);
            ExtendedMapRenderer.Init();

            LoadApplication(new App());
        }
    }
}

