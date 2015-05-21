using System.ComponentModel;
using RoundedBoxView.Forms.Plugin.iOSUnified;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:
    ExportRenderer(typeof (RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof (RoundedBoxViewRenderer))]

namespace RoundedBoxView.Forms.Plugin.iOSUnified
{
    /// <summary>
    /// Source From : https://gist.github.com/rudyryk/8cbe067a1363b45351f6
    /// </summary>
    public class RoundedBoxViewRenderer : BoxRenderer
    {
        /// <summary>
        ///     Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            if (Element == null) return;

            Layer.MasksToBounds = true;
            UpdateCornerRadius(Element as Abstractions.RoundedBoxView);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Abstractions.RoundedBoxView.CornerRadiusProperty.PropertyName)
            {
                UpdateCornerRadius(Element as Abstractions.RoundedBoxView);
            }
        }

        private void UpdateCornerRadius(Abstractions.RoundedBoxView box)
        {
            Layer.CornerRadius = (float) box.CornerRadius;
        }
    }
}
