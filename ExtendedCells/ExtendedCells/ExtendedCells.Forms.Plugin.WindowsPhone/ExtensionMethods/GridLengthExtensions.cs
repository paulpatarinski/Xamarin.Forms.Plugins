using System.Windows;
using GridUnitType = Xamarin.Forms.GridUnitType;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.ExtensionMethods
{
  public static class GridLengthExtensions
  {
    public static GridLength ToNative(this Xamarin.Forms.GridLength formsGridLength)
    {
      switch (formsGridLength.GridUnitType)
      {
        case GridUnitType.Absolute:
          return new GridLength(formsGridLength.Value, System.Windows.GridUnitType.Pixel);
        case GridUnitType.Auto:
          return new GridLength(formsGridLength.Value, System.Windows.GridUnitType.Auto);
        case GridUnitType.Star:
          return new GridLength(formsGridLength.Value, System.Windows.GridUnitType.Star);
      }

      return new GridLength(formsGridLength.Value, System.Windows.GridUnitType.Star);
    }
  }
}
