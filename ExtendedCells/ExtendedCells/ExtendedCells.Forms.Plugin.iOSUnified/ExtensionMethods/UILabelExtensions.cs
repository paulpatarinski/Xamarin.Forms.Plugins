using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ExtendedCells.Forms.Plugin.iOSUnified
{
	public static class UILabelExtensions
	{
		public static void UpdateFromFormsControl (this UILabel uiLabel, string text, TextAlignment textAlignment, Color textColor, Font font)
		{
			uiLabel.Text = text;
			uiLabel.TextAlignment = textAlignment.ToUITextAlignment ();
			uiLabel.TextColor = textColor.ToUIColor ();
			uiLabel.Font = font.ToUIFont ();
		}
	}
}

