using System;
using Xamarin.Forms;

namespace PluginSampleApp
{
	public static class Colors
	{
		public static Color DefaultColor {
			get {
				var color = Color.White;

				Device.OnPlatform (() => {
					color = Color.Black;
				});

				return color;
			}
		}

		public static Color BlackOrWhite {
			get {
				var color = Color.Black;

				Device.OnPlatform (() => {
					color = Color.White;
				});

				return color;
			}
		}
	}
}

