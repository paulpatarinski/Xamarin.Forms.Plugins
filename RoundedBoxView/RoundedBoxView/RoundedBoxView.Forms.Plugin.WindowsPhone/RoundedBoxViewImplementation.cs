using RoundedBoxView.Forms.Plugin.WindowsPhone;
using RoundedBoxView.Forms.Plugin.WindowsPhone.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace RoundedBoxView.Forms.Plugin.WindowsPhone
{
    /// <summary>
    /// RoundedBoxView Renderer
    /// </summary>
    public class RoundedBoxViewRenderer :  BoxViewRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        public Abstractions.RoundedBoxView FormsControl
        {
            get { return Element as Abstractions.RoundedBoxView; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            Control.RadiusX = FormsControl.CornerRadius;
            Control.RadiusY = FormsControl.CornerRadius;
            Control.Fill = FormsControl.BackgroundColor.ToBrush();
        }

        /// <summary>
        /// THIS NEEDS TO BE OVERWRITTEN OTHERWISE THE COLOR GETS SET INCORRECTLY
        /// </summary>
        protected override void UpdateBackgroundColor()
        {
        }
    }
}
