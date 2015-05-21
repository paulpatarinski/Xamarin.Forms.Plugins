using RoundedBoxView.Forms.Plugin.Abstractions;
using RoundedBoxView.Forms.Plugin.WindowsPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(RoundedBoxViewControl), typeof(RoundedBoxViewRenderer))]
namespace RoundedBoxView.Forms.Plugin.WindowsPhone
{
    /// <summary>
    /// RoundedBoxView Renderer
    /// </summary>
    public class RoundedBoxViewRenderer : BoxViewRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
        }
    }
}
