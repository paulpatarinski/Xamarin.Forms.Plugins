using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ExtendedCells.Forms.Plugin.iOSUnified
{
	public static class UILabelExtensions
	{
		public static void UpdateFromFormsControl (this UILabel uiLabel, string text, Xamarin.Forms.TextAlignment textAlignment, Color textColor, Font font)
		{
			uiLabel.Text = text;

			switch (textAlignment) {
			case TextAlignment.Start:
				uiLabel.TextAlignment = UITextAlignment.Left;
				break;
			case TextAlignment.Center: 
				uiLabel.TextAlignment = UITextAlignment.Center;
				break;
			case TextAlignment.End: 
				uiLabel.TextAlignment = UITextAlignment.Right;
				break;
			}

			uiLabel.TextColor = textColor.ToUIColor ();
			uiLabel.Font = font.ToUIFont ();
		}
	}
}

