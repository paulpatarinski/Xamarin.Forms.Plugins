using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ExtendedListview), typeof(ExtendedListviewRenderer))]
namespace ExtendedCells.Forms.Plugin.iOS
{
    /// <summary>
    /// SVG Renderer
    /// </summary>
    public class ExtendedListviewRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}
