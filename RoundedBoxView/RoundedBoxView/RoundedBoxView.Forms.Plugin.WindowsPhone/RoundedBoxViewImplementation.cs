using System.Windows;
using System.Windows.Controls;
using RoundedBoxView.Forms.Plugin.WindowsPhone;
using RoundedBoxView.Forms.Plugin.WindowsPhone.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using Rectangle = System.Windows.Shapes.Rectangle;
using Thickness = System.Windows.Thickness;

[assembly:
  ExportRenderer(typeof (RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof (RoundedBoxViewRenderer))]

namespace RoundedBoxView.Forms.Plugin.WindowsPhone
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

    public Abstractions.RoundedBoxView FormsControl
    {
      get { return Element; }
    }

    protected override void OnElementChanged(ElementChangedEventArgs<Abstractions.RoundedBoxView> e)
    {
      base.OnElementChanged(e);

      var relativeBorderThickness = FormsControl.BorderThickness * 1.7;
      var relativeBorderCornerRadius = FormsControl.CornerRadius * 1.25;

      var border = new Border
      {
        Height = FormsControl.HeightRequest,
        Width =  FormsControl.WidthRequest,
        CornerRadius = new CornerRadius(relativeBorderCornerRadius),
        Background = FormsControl.BorderColor.ToBrush(),
      };

      var rectHeight = FormsControl.HeightRequest - relativeBorderThickness;
      var rectWidth = FormsControl.WidthRequest - relativeBorderThickness;

      var rectangle = new Rectangle
      {
        Height  = rectHeight,
        Width = rectWidth,
        RadiusX = relativeBorderCornerRadius,
        RadiusY = relativeBorderCornerRadius,
        Fill = FormsControl.BackgroundColor.ToBrush()
      };

      border.Child = rectangle;

      SetNativeControl(border);
    }

    /// <summary>
    ///   THIS NEEDS TO BE OVERWRITTEN OTHERWISE THE COLOR GETS SET INCORRECTLY
    /// </summary>
    protected override void UpdateBackgroundColor()
    {
    }
  }
}