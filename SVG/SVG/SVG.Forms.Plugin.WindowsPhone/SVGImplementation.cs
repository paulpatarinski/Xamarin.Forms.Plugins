using SVG.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using SVG.Forms.Plugin.WindowsPhone;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(SVG.Forms.Plugin.Abstractions.SvgImage), typeof(SVGRenderer))]
namespace SVG.Forms.Plugin.WindowsPhone
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
