using ExtendedListview.Forms.Plugin.Abstractions;
using ExtendedListview.Forms.Plugin.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ExtendedListview.Forms.Plugin.Abstractions.ExtendedListview), typeof(ExtendedListviewRenderer))]

namespace ExtendedListview.Forms.Plugin.iOS
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