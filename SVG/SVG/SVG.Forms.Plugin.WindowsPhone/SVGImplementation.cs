using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Markup;
using SVG.Forms.Plugin.Abstractions;
using Xamarin.Forms;
using SVG.Forms.Plugin.WindowsPhone;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(SvgImage), typeof(SvgRenderer))]

namespace SVG.Forms.Plugin.WindowsPhone
{
    /// <summary>
    /// SVG Renderer
    /// </summary>
    public class SvgRenderer : ViewRenderer<SvgImage, Viewbox>
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SvgImage> e)
        {
            base.OnElementChanged(e);

            var svgImage = Element;

            var xamlFilePath = svgImage.SvgPath.Replace(".svg", ".xaml");
            var xamlStream = svgImage.SvgAssembly.GetManifestResourceStream(xamlFilePath);

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
                    var xaml = (Viewbox) XamlReader.Load(xamlString);

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