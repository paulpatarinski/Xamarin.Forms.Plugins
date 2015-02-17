using ExtendedListview.Forms.Plugin.Abstractions;
using ExtendedListview.Forms.Plugin.iOSUnified;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof (ExtendedListview), typeof (ExtendedListviewRenderer))]

namespace ExtendedListview.Forms.Plugin.iOSUnified
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