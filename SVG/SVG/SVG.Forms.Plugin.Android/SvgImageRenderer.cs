using System;
using Android.Widget;
using SVG.Forms.Plugin.Abstractions;
using SVG.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Threading.Tasks;

[assembly: ExportRenderer (typeof(SvgImage), typeof(SvgImageRenderer))]
namespace SVG.Forms.Plugin.Droid
{
	public class SvgImageRenderer : ViewRenderer<SvgImage,ImageView>
	{
		public static void Init ()
		{
		}

		private static bool _isGetBitmapExecuting;

		private SvgImage _formsControl {
			get {
				return Element as SvgImage;
			}
		}

		protected override async void OnElementChanged (ElementChangedEventArgs<SvgImage> e)
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

		public override SizeRequest GetDesiredSize (int widthConstraint, int heightConstraint)
		{
			return new SizeRequest (new Size (_formsControl.WidthRequest, _formsControl.WidthRequest));
		}

		private async Task UpdateBitmapFromSvgAsync ()
		{
			await Task.Run (async() => {
				var width = PixelToDP((int)_formsControl.WidthRequest <= 0 ? 100 : (int)_formsControl.WidthRequest);
				var height =  PixelToDP((int)_formsControl.HeightRequest <= 0 ? 100 : (int)_formsControl.HeightRequest);

				//Since you can only load one svg at a time, make sure the method is not already executing before calling it
				while (_isGetBitmapExecuting) {
					await Task.Delay (TimeSpan.FromMilliseconds (1));
				}

				_isGetBitmapExecuting = true;

				return await BitmapService.GetBitmapAsync (_formsControl, width, height);
			}).ContinueWith (taskResult => {
				var imageView = new ImageView (Context);

				imageView.SetScaleType (ImageView.ScaleType.FitXy);
				imageView.SetImageBitmap (taskResult.Result);

				SetNativeControl (imageView);
				_isGetBitmapExecuting = false;
			}, TaskScheduler.FromCurrentSynchronizationContext ());
		}

    /// <summary>
    /// http://stackoverflow.com/questions/24465513/how-to-get-detect-screen-size-in-xamarin-forms
    /// </summary>
    /// <param name="pixel"></param>
    /// <returns></returns>
    private int PixelToDP(int pixel) {
      var scale =Resources.DisplayMetrics.Density;
      return (int) ((pixel * scale) + 0.5f);
    }

	}
}