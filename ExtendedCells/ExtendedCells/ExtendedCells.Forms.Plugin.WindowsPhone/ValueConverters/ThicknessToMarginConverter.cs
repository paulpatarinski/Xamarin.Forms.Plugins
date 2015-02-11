using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.ValueConverters
{
  public class ThicknessToMarginConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var xamarinFormsThickness = (Xamarin.Forms.Thickness)value;

      return new Thickness(xamarinFormsThickness.Left, xamarinFormsThickness.Top, xamarinFormsThickness.Right,
        xamarinFormsThickness.Bottom);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
