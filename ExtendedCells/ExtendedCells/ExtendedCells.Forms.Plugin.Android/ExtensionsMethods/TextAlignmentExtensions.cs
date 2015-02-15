using Android.Views;

namespace ExtendedCells.Forms.Plugin.Android.ExtensionsMethods
{
  public static class TextAlignmentExtensions
  {
    public static GravityFlags ToNative(this Xamarin.Forms.TextAlignment textAlignment)
    {
      switch (textAlignment)
      {
        case Xamarin.Forms.TextAlignment.Center:
          return GravityFlags.Center;;
        case Xamarin.Forms.TextAlignment.Start:
          return GravityFlags.Start;
        case Xamarin.Forms.TextAlignment.End:
          return GravityFlags.End;
        default:
          return GravityFlags.Start;
      }
    }
  }
}