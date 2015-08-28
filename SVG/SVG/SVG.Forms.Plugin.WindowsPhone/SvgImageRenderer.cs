using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using SVG.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using SVG.Forms.Plugin.WindowsPhone;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(SvgImage), typeof(SvgImageRenderer))]

namespace SVG.Forms.Plugin.WindowsPhone
{
    /// <summary>
    /// SVG Renderer
    /// </summary>
    public class SvgImageRenderer : ViewRenderer<SvgImage, Viewbox>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
            var temp = DateTime.Now;
        }

        private SvgImage _formsControl
        {
          get { return Element as SvgImage; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SvgImage> e)
        {
            base.OnElementChanged(e);

            if (_formsControl != null && !string.IsNullOrWhiteSpace(_formsControl.SvgPath))
          {
            var xamlFilePath = _formsControl.SvgPath.Replace(".svg", ".xaml");
            var xamlStream = _formsControl.SvgAssembly.GetManifestResourceStream(xamlFilePath);

            if (xamlStream == null)
              throw new Exception(
                  string.Format(
                      "Not able to retrieve xaml file {0}. Make sure the Build Action is set to Embedded Resource",
                      xamlFilePath));

            using (var reader = new StreamReader(xamlStream))
            {
              var xamlString = reader.ReadToEnd();

              try
              {
                var xaml = (Viewbox)XamlReader.Load(xamlString);

                switch (_formsControl.Aspect)
                {
                  case Aspect.AspectFill:
                    xaml.Stretch = Stretch.UniformToFill;
                    break;
                  case Aspect.AspectFit:
                    xaml.Stretch = Stretch.Uniform;
                    break;
                  case Aspect.Fill:
                    xaml.Stretch = Stretch.Fill;
                    break;
                  default:
                    xaml.Stretch = Stretch.None;
                    break;
                }

                SetNativeControl(xaml);
              }
              catch (Exception)
              {
                throw new Exception(
                    string.Format(
                        "Not able to convert xaml file {0} to Viewbox. Make sure the root element of the xaml file is a Viewbox",
                        xamlFilePath));
              }
            }
          }
        }
    }
}