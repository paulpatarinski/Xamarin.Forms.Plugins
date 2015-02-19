using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace ExtendedCells.Forms.Plugin.iOS
{
	public static class UILabelExtensions
	{
		public static void UpdateFromFormsControl (this UILabel uiLable, string text, TextAlignment textAlignment, Color textColor)
		{
			uiLable.Text = text;
			uiLable.TextAlignment = textAlignment.ToUITextAlignment ();
			uiLable.TextColor = textColor.ToUIColor ();

		}
	}
}

