using System.Windows;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.ExtensionMethods
{
  public static class TextAlignmentExtensions
  {
    public static TextAlignment ToNative(this Xamarin.Forms.TextAlignment formsTextAlignment)
    {
      switch (formsTextAlignment)
      {
        case Xamarin.Forms.TextAlignment.Center:
          return TextAlignment.Center;
        case Xamarin.Forms.TextAlignment.End:
          return TextAlignment.Right;
        case Xamarin.Forms.TextAlignment.Start:
          return TextAlignment.Left;
      }

      return TextAlignment.Center;
    }
  }
}