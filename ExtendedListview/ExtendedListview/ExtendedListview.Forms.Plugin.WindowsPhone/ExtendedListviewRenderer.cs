using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.WindowsPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(ExtendedListview), typeof(ExtendedListviewRenderer))]

namespace ExtendedCells.Forms.Plugin.WindowsPhone
{
    /// <summary>
    /// Two Column Cell
    /// </summary>
  public class ExtendedListviewRenderer : ViewCellRenderer
  {
      public static void Init()
      {
      }
      
  }
}