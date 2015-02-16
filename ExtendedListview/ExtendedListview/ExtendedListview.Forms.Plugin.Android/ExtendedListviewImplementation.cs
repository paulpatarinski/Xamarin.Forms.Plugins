using ExtendedListview.Forms.Plugin.Abstractions;
using ExtendedListview.Forms.Plugin.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof (ExtendedListviewControl), typeof (ExtendedListviewRenderer))]

namespace ExtendedListview.Forms.Plugin.Droid
{
  /// <summary>
  ///   ExtendedListview Renderer
  /// </summary>
  public class ExtendedListviewRenderer //: TRender (replace with renderer type
  {
    /// <summary>
    ///   Used for registration with dependency service
    /// </summary>
    public static void Init()
    {
    }
  }
}