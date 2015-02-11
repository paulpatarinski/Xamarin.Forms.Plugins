using System;
using System.Globalization;
using ExtendedCells.Forms.Plugin.WindowsPhone.ExtensionMethods;
using Xamarin.Forms;
using IValueConverter = System.Windows.Data.IValueConverter;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.ValueConverters
{
  public class ToNativeColorConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return ((Color)value).ToBrush();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
