using Xamarin.Forms;
using SVG.Forms.Plugin.iOS;
using Xamarin.Forms.Platform.iOS;
using System.IO;
using SVG.Forms.Plugin.Abstractions;
using NGraphics;
using UIKit;
using System;
using CoreGraphics;
using Foundation;
using NGraphics.Custom.Parsers;
using NGraphics.iOS.Custom;

[assembly: ExportRenderer(typeof(SVG.Forms.Plugin.Abstractions.SvgImage), typeof(SvgImageRenderer))]
namespace SVG.Forms.Plugin.iOS
{
    /// <summary>
    /// SVG Renderer
    /// </summary>
    [Preserve(AllMembers = true)]
    public class SvgImageRenderer : ImageRenderer
    {
      /// <summary>
      ///   Used for registration with dependency service
      /// </summary>
      public static void Init()
      {
          var temp = DateTime.Now;
      }

      private SvgImage _formsControl
      {
        get { return Element as SvgImage; }
      }

      protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
      {
        base.OnElementChanged(e);

        if (_formsControl != null)
        {
          var svgStream = _formsControl.SvgAssembly.GetManifestResourceStream(_formsControl.SvgPath);

          if (svgStream == null)
          {
            throw new Exception(string.Format("Error retrieving {0} make sure Build Action is Embedded Resource",
              _formsControl.SvgPath));
          }

          var r = new SvgReader(new StreamReader(svgStream), new StylesParser(new ValuesParser()), new ValuesParser());

          var graphics = r.Graphic;

          var width = _formsControl.WidthRequest <= 0 ? 100 : _formsControl.WidthRequest;
          var height = _formsControl.HeightRequest <= 0 ? 100 : _formsControl.HeightRequest;

          var scale = 1.0;

          if (height >= width)
          {
            scale = height/graphics.Size.Height;
          }
          else
          {
            scale = width/graphics.Size.Width;
          }

          var scaleFactor = UIScreen.MainScreen.Scale;

          var canvas = new ApplePlatform().CreateImageCanvas(graphics.Size, scale*scaleFactor);
          graphics.Draw(canvas);
          var image = canvas.GetImage();

          var uiImage = image.GetUIImage();
          Control.Image = uiImage;
        }
      }
    }
}