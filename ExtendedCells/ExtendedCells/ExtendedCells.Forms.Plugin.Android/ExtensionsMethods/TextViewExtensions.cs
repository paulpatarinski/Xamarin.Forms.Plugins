using Android.Util;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace ExtendedCells.Forms.Plugin.Android.ExtensionsMethods
{
    public static class TextViewExtensions 
    {
        public static void UpdateFont(this TextView textView, Font font)
        {
            if (font == Font.Default)
                return;
            textView.Typeface = font.ToTypeface();
            textView.SetTextSize(ComplexUnitType.Sp, font.ToScaledPixel());
        }

        public static void UpdateFromFormsControl(this TextView textView, string text, Color formsColor, Font formsFont, TextAlignment textAlignment)
        {
            textView.Text = text;
            textView.SetTextColor(formsColor.ToAndroid(Color.Default));
            textView.UpdateFont(formsFont);
            textView.Gravity = textAlignment.ToNative();
        }
    }
}