using Xamarin.Forms;
using SVG.Forms.Plugin.iOS;

[assembly: ExportRenderer(typeof(SVG.Forms.Plugin.Abstractions.TwoColumnCell), typeof(TwoColumnCellRenderer))]
namespace SVG.Forms.Plugin.iOS
{
    /// <summary>
    /// SVG Renderer
    /// </summary>
    public class TwoColumnCellRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}
