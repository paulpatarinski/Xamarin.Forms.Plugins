using System.ComponentModel;
using Android.Graphics;
using RoundedBoxView.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System;
using Android.Graphics.Drawables.Shapes;
using Android.Graphics.Drawables;
using RoundedBoxView.Forms.Plugin.iOSUnified.ExtensionMethods;


[assembly: ExportRenderer(typeof(RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace RoundedBoxView.Forms.Plugin.Droid
{
    /// <summary>
    /// Source from https://gist.github.com/rudyryk/8cbe067a1363b45351f6
    /// </summary>
	public class RoundedBoxViewRenderer : ViewRenderer<RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView, Android.Views.View>
    {
        public static void Init() { }

		private RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView _formControl {
			get{
				return Element as RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView;
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView> e)
		{
			base.OnElementChanged(e);

			this.UpdateFrom (_formControl);

		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			this.UpdateFrom (_formControl);
		}


//		protected override void OnElementChanged(ElementChangedEventArgs<RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView> e)
//        {
//            base.OnElementChanged(e);
//
//			if (_formControl == null)
//				return;
//
//
//
//			var relativeCornerRadius = (float)(_formControl.CornerRadius * 3.7);
//			var relativeBorderThickness = _formControl.BorderThickness * 3;
//
//			var shape = new GradientDrawable ();
//
//			shape.SetCornerRadius (relativeCornerRadius);
//			shape.SetColor (_formControl.BackgroundColor.ToAndroid ());
//			shape.SetStroke (relativeBorderThickness, _formControl.BorderColor.ToAndroid ());
//
//			Background = shape;
//        }
    }
}