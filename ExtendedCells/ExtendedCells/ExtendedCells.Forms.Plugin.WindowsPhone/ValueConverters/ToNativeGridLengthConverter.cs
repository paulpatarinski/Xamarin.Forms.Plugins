using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ExtendedCells.Forms.Plugin.WindowsPhone.ExtensionMethods;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.ValueConverters
{
  public class ToNativeGridLengthConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var defaultGridLength = new GridLength(0.5, GridUnitType.Star);

      if (value == null)
      {
        return defaultGridLength;
      }

      var xamarinFormsGridLength = (Xamarin.Forms.GridLength) (value);

      if (Math.Abs(xamarinFormsGridLength.Value) < 0.0001)
      {
        return defaultGridLength;
      }

      return xamarinFormsGridLength.ToNative();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
