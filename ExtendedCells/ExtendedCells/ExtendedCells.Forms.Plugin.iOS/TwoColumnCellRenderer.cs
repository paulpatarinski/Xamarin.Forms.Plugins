using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(TwoColumnCell), typeof(TwoColumnCellRenderer))]
namespace ExtendedCells.Forms.Plugin.iOS
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
