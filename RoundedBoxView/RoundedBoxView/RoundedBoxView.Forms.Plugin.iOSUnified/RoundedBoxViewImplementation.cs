using System.ComponentModel;
using RoundedBoxView.Forms.Plugin.iOSUnified;
using RoundedBoxView.Forms.Plugin.iOSUnified.ExtensionMethods;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:
  ExportRenderer(typeof (RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof (RoundedBoxViewRenderer))]

namespace RoundedBoxView.Forms.Plugin.iOSUnified
{
  /// <summary>
  ///   Source From : https://gist.github.com/rudyryk/8cbe067a1363b45351f6
  /// </summary>
  public class RoundedBoxViewRenderer : BoxRenderer
  {
    /// <summary>
    ///   Used for registration with dependency service
    /// </summary>
    public static void Init()
    {
    }

    private Abstractions.RoundedBoxView _formControl
    {
      get { return Element as Abstractions.RoundedBoxView; }
    }

    protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
    {
      base.OnElementChanged(e);

      this.InitializeFrom(_formControl);
    }

    protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      base.OnElementPropertyChanged(sender, e);

      this.UpdateFrom(_formControl, e.PropertyName);
    }
  }
}
