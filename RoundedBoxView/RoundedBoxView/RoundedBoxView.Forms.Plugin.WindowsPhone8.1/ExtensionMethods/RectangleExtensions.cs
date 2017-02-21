using Color = Xamarin.Forms.Color;

namespace RoundedBoxView.Forms.Plugin.WindowsPhone8._1.ExtensionMethods
{
    using Windows.UI.Xaml.Shapes;

    public static class RectangleExtensions
    {
        public static void InitializeFrom(this Rectangle nativeControl, Abstractions.RoundedBoxView formsControl)
        {
            if (nativeControl == null || formsControl == null)
                return;

            nativeControl.UpdateCornerRadius(formsControl.CornerRadius);
            nativeControl.UpdateBackgroundColor(formsControl.BackgroundColor);
            nativeControl.UpdateBorderThickness(formsControl.BorderThickness, formsControl.HeightRequest, formsControl.WidthRequest);
        }

        public static void UpdateCornerRadius(this Rectangle nativeControl, double cornerRadius)
        {
            var relativeBorderCornerRadius = cornerRadius * 1.25;

            nativeControl.RadiusX = relativeBorderCornerRadius;
            nativeControl.RadiusY = relativeBorderCornerRadius;
        }

        public static void UpdateBackgroundColor(this Rectangle nativeControl, Color backgroundColor)
        {
            nativeControl.Fill = backgroundColor.ToBrush();
        }

        /// <summary>
        /// Changes the border size by changing the height and width of the rectangle
        /// </summary>
        /// <param name="nativeControl"></param>
        /// <param name="borderThickness"></param>
        /// <param name="formsControlHeightRequest"></param>
        /// <param name="formsControlWidthRequest"></param>
        public static void UpdateBorderThickness(this Rectangle nativeControl, int borderThickness, double formsControlHeightRequest, double formsControlWidthRequest)
        {
            var relativeBorderThickness = borderThickness * 1.7;

            var rectHeight = formsControlHeightRequest - relativeBorderThickness;
            var rectWidth = formsControlWidthRequest - relativeBorderThickness;

            nativeControl.Height = rectHeight;
            nativeControl.Width = rectWidth;
        }
    }
}
