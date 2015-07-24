using Android.Graphics.Drawables;
using RoundedBoxView.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly:
  ExportRenderer(typeof (RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof (RoundedBoxViewRenderer))]

namespace RoundedBoxView.Forms.Plugin.Droid
{
  public class RoundedBoxViewRenderer : ViewRenderer<Abstractions.RoundedBoxView, View>
  {
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

      if (_formControl == null)
        return;

      var relativeCornerRadius = (float) (_formControl.CornerRadius*3.7);
      var relativeBorderThickness = _formControl.BorderThickness*3;

      var shape = new GradientDrawable();

      shape.SetCornerRadius(relativeCornerRadius);
      shape.SetColor(_formControl.BackgroundColor.ToAndroid());
      shape.SetStroke(relativeBorderThickness, _formControl.BorderColor.ToAndroid());

      Background = shape;
    }
  }
}