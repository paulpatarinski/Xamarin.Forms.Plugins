using SVG.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using SVG.Forms.Plugin.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SVG.Forms.Plugin.Abstractions.SVGControl), typeof(SVGRenderer))]
namespace SVG.Forms.Plugin.Android
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