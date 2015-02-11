using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ExtendedCells.Forms.Plugin.WindowsPhone.ExtensionMethods;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.ValueConverters
{
  public class ToNativeTextAlignmentConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value == null ? TextAlignment.Left : ((Xamarin.Forms.TextAlignment) value).ToNative();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
