using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.ValueConverters
{
  public class TextToVisibilityConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
      {
        return Visibility.Collapsed;
      }

      return string.IsNullOrEmpty(value.ToString()) ? Visibility.Collapsed : Visibility.Visible;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
