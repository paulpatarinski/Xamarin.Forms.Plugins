using Android.App;
using Android.Content.PM;
using Android.OS;
using ExtendedCells.Forms.Plugin.Android;
using ExtendedMap.Forms.Plugin.Droid;
using SVG.Forms.Plugin.Droid;
using Xamarin;

namespace SampleApp.Droid
{
	[Activity (MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			FormsMaps.Init (this, bundle);
			SvgImageRenderer.Init ();
			ExtendedTextCellRenderer.Init ();
			ExtendedMapRenderer.Init ();

			LoadApplication (new App ());
		}
	}
}

