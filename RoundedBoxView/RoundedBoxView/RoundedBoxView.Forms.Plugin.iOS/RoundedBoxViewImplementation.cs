using RoundedBoxView.Forms.Plugin.Abstractions;
using System;
using Xamarin.Forms;
using RoundedBoxView.Forms.Plugin.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxViewControl), typeof(RoundedBoxViewRenderer))]
namespace RoundedBoxView.Forms.Plugin.iOS
{
    /// <summary>
    /// RoundedBoxView Renderer
    /// </summary>
    public class RoundedBoxViewRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}
