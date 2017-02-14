using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using RoundedBoxView.Forms.Plugin.WindowsUniversal;
using RoundedBoxView.Forms.Plugin.WindowsUniversal.ExtensionMethods;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly:ExportRenderer(typeof(RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace RoundedBoxView.Forms.Plugin.WindowsUniversal
{
    /// <summary>
    ///   RoundedBoxView Renderer
    /// </summary>
    public class RoundedBoxViewRenderer : ViewRenderer<Abstractions.RoundedBoxView, Border>
    {
        /// <summary>
        ///   Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        private Abstractions.RoundedBoxView FormControl
        {
            get { return Element; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Abstractions.RoundedBoxView> e)
        {
            base.OnElementChanged(e);

            var border = new Border();

            border.InitializeFrom(FormControl);

            Element.BackgroundColor = Color.Transparent;

            SetNativeControl(border);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.UpdateFrom(FormControl, e.PropertyName);
        }
    }
}
