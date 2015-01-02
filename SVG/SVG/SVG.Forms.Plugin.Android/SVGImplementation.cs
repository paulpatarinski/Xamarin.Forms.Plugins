using SVG.Forms.Plugin.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(SVG.Forms.Plugin.Abstractions.SvgImage), typeof(SVGRenderer))]
namespace SVG.Forms.Plugin.Droid
{
    /// <summary>
    /// SVG Renderer
    /// </summary>
    public class SVGRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}