using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Android.Widget;
using SVG.Forms.Plugin.Abstractions;
using SVG.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamSvg;

[assembly: ExportRenderer (typeof(SvgImage), typeof(SvgImageRenderer))]

namespace SVG.Forms.Plugin.Droid
{
    public class SvgImageRenderer : ImageRenderer
    {
        private bool _svgSourceSet;
        private Dictionary<string, Stream> _svgStreamByPath;

        private Dictionary<string, Stream> SvgStreamByPath
        {
            get
            {
                if (_svgStreamByPath == null)
                {
                    _svgStreamByPath = new Dictionary<string, Stream>();
                }

                return _svgStreamByPath;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var imageView = Control as ImageView;
            var formsControl = sender as SvgImage;

            if (imageView != null && formsControl != null && !formsControl.IsLoading && !_svgSourceSet)
            {
                try
                {
                    _svgSourceSet = true;

                    var width = (int) formsControl.WidthRequest <= 0 ? 100 : (int) formsControl.WidthRequest;
                    var height = (int) formsControl.HeightRequest <= 0 ? 100 : (int) formsControl.HeightRequest;

                    var svg = SvgFactory.GetBitmap(GetSvgStream(formsControl.SvgPath), width, height);

                    imageView.SetImageBitmap(svg);
                }
                catch (Exception ex)
                {
                    throw new Exception("Problem setting image source", ex);
                }
            }
        }

        private Stream GetSvgStream(string svgPath)
        {
            Stream stream = null;
            //Insert into Dictionary
            if (!SvgStreamByPath.ContainsKey(svgPath))
            {
                var assembly = typeof (SvgImage).GetTypeInfo().Assembly;
                stream = assembly.GetManifestResourceStream(svgPath);

                SvgStreamByPath.Add(svgPath, stream);

                return stream;
            }

            //Get from dictionary
            stream = SvgStreamByPath[svgPath];
            //Reset the stream position otherwise an error is thrown (SvgFactory.GetBitmap sets the position to position max)
            stream.Position = 0;

            return stream;
        }
    }
}