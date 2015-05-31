using Xamarin.Forms;
using SVG.Forms.Plugin.iOS;
using Xamarin.Forms.Platform.iOS;
using System.IO;
using SVG.Forms.Plugin.Abstractions;
using NGraphics;
using UIKit;
using NGraphics.Parsers;
using System;
using CoreGraphics;

[assembly: ExportRenderer(typeof(SVG.Forms.Plugin.Abstractions.SvgImage), typeof(SvgImageRenderer))]
namespace SVG.Forms.Plugin.iOS
{
    /// <summary>
    /// SVG Renderer
    /// </summary>
	public class SvgImageRenderer :  ImageRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);

			var svgImage = Element as SvgImage;

			if (svgImage == null) {
				//Add an SVGImage to a StackLayout and call Children.RemoveAt(0) (or Remove(item))
				//and you'll get a nullpointer exception below so bail out if the item is being disposed
				return;
			}

			var svgStream = svgImage.SvgAssembly.GetManifestResourceStream(svgImage.SvgPath);

			if (svgStream == null) {
				throw new Exception (string.Format ("Error retrieving {0} make sure Build Action is Embedded Resource", svgImage.SvgPath));
			}

			var r = new SvgReader(new StreamReader(svgStream), new StylesParser(new ValuesParser()),new ValuesParser());

			var graphics = r.Graphic;

			var width = svgImage.WidthRequest == 0 ? 100 : svgImage.WidthRequest;
			var height = svgImage.HeightRequest == 0 ? 100 : svgImage.HeightRequest;

			var scale = 1.0;

			if (height >= width) {
					scale = height / graphics.Size.Height;
			} else {
				scale = width / graphics.Size.Width;
			}

			var scaleFactor = UIScreen.MainScreen.Scale;

			var canvas = new ApplePlatform().CreateImageCanvas(graphics.Size, scale * scaleFactor);
			graphics.Draw(canvas);
			var image = canvas.GetImage ();

			var uiImage = image.GetUIImage ();
			Control.Image = uiImage;
		}
    }
}
