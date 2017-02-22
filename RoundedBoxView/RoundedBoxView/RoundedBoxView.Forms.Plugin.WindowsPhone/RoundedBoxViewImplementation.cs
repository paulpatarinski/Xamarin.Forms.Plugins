using System.ComponentModel;
using RoundedBoxView.Forms.Plugin.WindowsPhone;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace RoundedBoxView.Forms.Plugin.WindowsPhone
{
    using System.Windows.Controls;
    using ExtensionMethods;
    using Xamarin.Forms.Platform.WinPhone;

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

        private Abstractions.RoundedBoxView _formControl
        {
            get { return Element; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Abstractions.RoundedBoxView> e)
        {
            base.OnElementChanged(e);

            var border = new Border();

            border.InitializeFrom(_formControl);

            SetNativeControl(border);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.UpdateFrom(_formControl, e.PropertyName);
        }
    }
}