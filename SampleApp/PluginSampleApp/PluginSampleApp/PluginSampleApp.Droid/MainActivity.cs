using Android.App;
using Android.Content.PM;
using Android.OS;
using ExtendedCells.Forms.Plugin.Android;
using ExtendedMap.Forms.Plugin.Droid;
using SVG.Forms.Plugin.Droid;
using Xamarin;
using Xamarin.Forms.Platform.Android;

namespace PluginSampleApp.Droid
{
	[Activity (MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			Xamarin.Forms.Forms.Init (this, bundle);
			FormsMaps.Init (this, bundle);

			SvgImageRenderer.Init ();
			TwoColumnCellRenderer.Init ();
			ExtendedMapRenderer.Init ();

			LoadApplication (new App ());
		}
	}
}

