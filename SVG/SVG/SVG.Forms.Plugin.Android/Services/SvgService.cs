using System;
using System.IO;
using System.Collections.Generic;
using SVG.Forms.Plugin.Abstractions;
using System.Threading.Tasks;

namespace SVG.Forms.Plugin.Droid
{
	public static class SvgService
	{
		private static Dictionary<string, Stream> _svgStreamByPath;

		/// <summary>
		/// This Dictionary is static, so that all Custom Renderers share it
		/// </summary>
		/// <value>The svg stream by path.</value>
		private static Dictionary<string, Stream> SvgStreamByPath {
			get {
				if (_svgStreamByPath == null) {
					_svgStreamByPath = new Dictionary<string, Stream> ();
				}

				return _svgStreamByPath;
			}
		}



		public static async Task<Stream> GetSvgStreamAsync (SvgImage svgImage)
		{
			Stream stream = null;

			//Insert into Dictionary
			if (!SvgStreamByPath.ContainsKey (svgImage.SvgPath)) {
				if (svgImage.SvgAssembly == null)
					throw new Exception ("Svg Assembly not specified. Please specify assembly using the SvgImage Control SvgAssembly property.");

				stream = svgImage.SvgAssembly.GetManifestResourceStream (svgImage.SvgPath);

				if (stream == null)
					throw new Exception (string.Format ("Not able to retrieve svg from {0} make sure the svg is an Embedded Resource and the path is set up correctly", svgImage.SvgPath));

				SvgStreamByPath.Add (svgImage.SvgPath, stream);

				return await Task.FromResult<Stream> (stream);
			}

			//Get from dictionary
			stream = SvgStreamByPath [svgImage.SvgPath];
			//Reset the stream position otherwise an error is thrown (SvgFactory.GetBitmap sets the position to position max)
			stream.Position = 0;

			return await Task.FromResult<Stream> (stream);
		}
	}
}

