using Android.Content;
using Android.Views;
using Android.Widget;
using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof (ExtendedListview), typeof (ExtendedListviewRenderer))]

namespace ExtendedCells.Forms.Plugin.Android
{
  /// <summary>
  ///   TwoColumn Cell renderer for Android
  /// </summary>
  public class ExtendedListviewRenderer : CellRenderer
  {
    /// <summary>
    ///   Call this method to make sure the assembly gets loaded
    /// </summary>
    public static void Init()
    {
    }
  }
}