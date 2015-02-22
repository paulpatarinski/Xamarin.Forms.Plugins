using System;
using Android.Widget;
using SVG.Forms.Plugin.Abstractions;
using SVG.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamSvg;
using System.Threading.Tasks;

[assembly: ExportRenderer (typeof(SvgImage), typeof(SvgImageRenderer))]
namespace SVG.Forms.Plugin.Droid
{
	public class SvgImageRenderer : ImageRenderer
	{
		public static void Init ()
		{
		}

		private static bool _isGetBitmapExecuting;
		private SvgImage _formsControl;

		protected override async void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				try {
					await UpdateBitmapFromSvgAsync ();
				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine ("Problem setting image source {0}", ex);
				}
			}
		}

		private async Task UpdateBitmapFromSvgAsync ()
		{
			var imageView = Control as ImageView;
			_formsControl = Element as SvgImage;


			await Task.Run (async() => {

				var width = (int)_formsControl.WidthRequest <= 0 ? 100 : (int)_formsControl.WidthRequest;
				var height = (int)_formsControl.HeightRequest <= 0 ? 100 : (int)_formsControl.HeightRequest;

				//Since you can only load one svg at a time, make sure the method is not already executing before calling it
				while (_isGetBitmapExecuting) {
					await Task.Delay (TimeSpan.FromMilliseconds (1));
				}

				_isGetBitmapExecuting = true;

				return SvgFactory.GetBitmap (SvgService.GetSvgStream (_formsControl), width, height);
			}).ContinueWith (taskResult => {
				imageView.SetScaleType (ImageView.ScaleType.FitXy);
				imageView.SetImageBitmap (taskResult.Result);
				_isGetBitmapExecuting = false;
			}, TaskScheduler.FromCurrentSynchronizationContext ());
		}
	}
}