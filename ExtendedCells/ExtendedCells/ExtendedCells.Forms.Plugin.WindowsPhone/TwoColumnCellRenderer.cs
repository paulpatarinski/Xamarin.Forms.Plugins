using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.WindowsPhone;
using ExtendedCells.Forms.Plugin.WindowsPhone.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using DataTemplate = System.Windows.DataTemplate;

[assembly: ExportRenderer(typeof(TwoColumnCell), typeof(TwoColumnCellRenderer))]

namespace ExtendedCells.Forms.Plugin.WindowsPhone
{
    /// <summary>
    /// Two Column Cell
    /// </summary>
  public class TwoColumnCellRenderer : ViewCellRenderer
  {
      public static void Init()
      {
      }

    private NativeListviewControl _nativeListviewControl;

    public NativeListviewControl NativeListviewControl
    {
      get
      {
        if (_nativeListviewControl == null)
        {
          _nativeListviewControl = new NativeListviewControl();
        }

        return _nativeListviewControl;
      }
    }

    public override DataTemplate GetTemplate(Cell cell)
    {
      return NativeListviewControl.TwoColumnCellTemplate;
    }

      
  }
}