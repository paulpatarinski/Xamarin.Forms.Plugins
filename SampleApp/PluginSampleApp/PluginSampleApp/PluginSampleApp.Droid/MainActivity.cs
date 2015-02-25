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

			// http://forums.xamarin.com/discussion/21148/calabash-and-xamarin-forms-what-am-i-missing
			global::Xamarin.Forms.Forms.ViewInitialized += (object sender, Xamarin.Forms.ViewInitializedEventArgs e) => {
				if (!string.IsNullOrWhiteSpace(e.View.StyleId)) {
					e.NativeView.ContentDescription = e.View.StyleId;
				}
			};

			LoadApplication (new App ());
		}
	}
}

