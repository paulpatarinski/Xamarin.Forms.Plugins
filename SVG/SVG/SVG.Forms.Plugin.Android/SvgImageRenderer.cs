using System;
using System.Collections.Generic;
using System.IO;
using Android.Widget;
using SVG.Forms.Plugin.Abstractions;
using SVG.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamSvg;

[assembly: ExportRenderer (typeof(SvgImage), typeof(SvgImageRenderer))]

namespace SVG.Forms.Plugin.Droid
{
	public class SvgImageRenderer : ImageRenderer
	{
		public static void Init ()
		{
		}

		private bool _svgSourceSet;
		private static Dictionary<string, Stream> _svgStreamByPath;
		private SvgImage _formsControl;

		private static Dictionary<string, Stream> SvgStreamByPath {
			get {
				if (_svgStreamByPath == null) {
					_svgStreamByPath = new Dictionary<string, Stream> ();
				}

				return _svgStreamByPath;
			}
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);

			if (e.OldElement == null) {
				try {
					UpdateBitmapFromSvg ();
				} catch (Exception ex) {
					throw new Exception ("Problem setting image source", ex);
				}
			}
		}

		private void UpdateBitmapFromSvg ()
		{
			var imageView = Control as ImageView;
			_formsControl = Element as SvgImage;

			_svgSourceSet = true;

			var width = (int)_formsControl.WidthRequest <= 0 ? 100 : (int)_formsControl.WidthRequest;
			var height = (int)_formsControl.HeightRequest <= 0 ? 100 : (int)_formsControl.HeightRequest;

			var svg = SvgFactory.GetBitmap (GetSvgStream (_formsControl.SvgPath), width, height);
			imageView.SetScaleType (ImageView.ScaleType.FitXy);
			imageView.SetImageBitmap (svg);
		}

		private Stream GetSvgStream (string svgPath)
		{
			Stream stream = null;
			//Insert into Dictionary
			if (!SvgStreamByPath.ContainsKey (svgPath)) {
				if (_formsControl.SvgAssembly == null)
					throw new Exception ("Svg Assembly not specified. Please specify assembly using the SvgImage Control SvgAssembly property.");

				stream = _formsControl.SvgAssembly.GetManifestResourceStream (svgPath);

				if (stream == null)
					throw new Exception (string.Format ("Not able to retrieve svg from {0} make sure the svg is an Embedded Resource and the path is set up correctly", svgPath));

				SvgStreamByPath.Add (svgPath, stream);

				return stream;
			}

			//Get from dictionary
			stream = SvgStreamByPath [svgPath];
			//Reset the stream position otherwise an error is thrown (SvgFactory.GetBitmap sets the position to position max)
			stream.Position = 0;

			return stream;
		}
	}
}