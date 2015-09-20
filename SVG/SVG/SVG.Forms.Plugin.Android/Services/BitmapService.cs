using System.Threading.Tasks;
using Android.Graphics;
using System.IO;
using NGraphics.Android.Custom;
using NGraphics.Custom.Parsers;
using SVG.Forms.Plugin.Abstractions;

namespace SVG.Forms.Plugin.Droid
{
	public static class BitmapService
	{
		public static async Task<Bitmap> GetBitmapAsync (SvgImage svgImage, int width, int height)
		{
			Bitmap result = null;

			Stream svgStream = await SvgService.GetSvgStreamAsync (svgImage).ConfigureAwait (false);

      await Task.Run(() =>
      {
        var svgReader = new SvgReader(new StreamReader(svgStream), new StylesParser(new ValuesParser()), new ValuesParser());

        var graphics = svgReader.Graphic;

        var newWidth = svgImage.WidthRequest == 0 ? 100 : svgImage.WidthRequest;
        var newHeight = svgImage.HeightRequest == 0 ? 100 : svgImage.HeightRequest;

        var scale = 1.0;

        if (height >= width)
        {
          scale = height / graphics.Size.Height;
        }
        else
        {
          scale = width / graphics.Size.Width;
        }

        var canvas = new AndroidPlatform().CreateImageCanvas(graphics.Size, scale);
        graphics.Draw(canvas);
        var image = (BitmapImage)canvas.GetImage();
        result = image.Bitmap;

        //result = SvgFactory.GetBitmap(svgStream, width, height);
      });

			return result;
		}
	}
}