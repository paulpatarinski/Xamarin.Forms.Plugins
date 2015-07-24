using System.Windows.Media;

namespace RoundedBoxView.Forms.Plugin.WindowsPhone.ExtensionMethods
{
    /// <summary>
    /// From Xam Forms Labs https://github.com/XLabs/Xamarin-Forms-Labs/blob/248cfcfc5b5803f5c3a157e51df57c08706a84ba/src/Forms/XLabs.Forms.WP8/Extensions/ColorExtensions.cs
    /// </summary>
    public static class ColorExtensions
    {
        public static Brush ToBrush(this Xamarin.Forms.Color color)
        {
            return new SolidColorBrush(color.ToMediaColor());
        }

        public static Color ToMediaColor(this Xamarin.Forms.Color color)
        {
            return Color.FromArgb((byte)(color.A * 255.0), (byte)(color.R * 255.0), (byte)(color.G * 255.0), (byte)(color.B * 255.0));
        }
    }
}
