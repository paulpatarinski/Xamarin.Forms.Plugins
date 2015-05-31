using Xamarin.Forms;

namespace RoundedBoxView.Forms.Plugin.Abstractions
{
    public class RoundedBoxView : BoxView
    {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create("CornerRadius", typeof (double), typeof (RoundedBoxView), default(double));

        public double CornerRadius
        {
            get { return (double) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
