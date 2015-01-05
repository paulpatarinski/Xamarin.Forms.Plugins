using ExtendedMap.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using ExtendedMap.Forms.Plugin.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof(ExtendedMapRenderer))]
namespace ExtendedMap.Forms.Plugin.iOS
{
    /// <summary>
    /// ExtendedMap Renderer
    /// </summary>
    public class ExtendedMapRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}
