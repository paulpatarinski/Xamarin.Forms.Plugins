using System.ComponentModel;
using RoundedBoxView.Forms.Plugin.Droid;
using RoundedBoxView.Forms.Plugin.Droid.ExtensionMethods;
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

      this.CreateFrom(_formControl);
    }

    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      base.OnElementPropertyChanged(sender, e);

      this.UpdateFrom(_formControl, e.PropertyName);
    }
  }
}