using System;
using System.Threading.Tasks;
using Android.Graphics;
using System.IO;
using SVG.Forms.Plugin.Abstractions;
using XamSvg;

namespace SVG.Forms.Plugin.Droid
{
	public static class BitmapService
	{
		public static async Task<Bitmap> GetBitmapAsync (SvgImage svgImage, int width, int height)
		{
			Bitmap result = null;

			Stream stream = await SvgService.GetSvgStreamAsync (svgImage).ConfigureAwait (false); 

			await Task.Run (() => {
				result = SvgFactory.GetBitmap (stream, width, height);
			});

			return result;
		}
	}
}