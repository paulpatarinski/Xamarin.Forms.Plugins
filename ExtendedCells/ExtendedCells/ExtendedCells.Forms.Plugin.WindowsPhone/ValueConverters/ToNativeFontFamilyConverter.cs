using System;
using System.Globalization;
using System.Windows.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using IValueConverter = System.Windows.Data.IValueConverter;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.ValueConverters
{
  public class ToNativeFontFamilyConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var xamarinFormsFont = (Font)value ;
     
      //Need a TextBlock so that I can call the extension method
      var tempTextBlock = new TextBlock();
      
      tempTextBlock.ApplyFont(xamarinFormsFont);

      return tempTextBlock.FontFamily;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
