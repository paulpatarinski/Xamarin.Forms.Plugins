using System.ComponentModel;
using Android.Graphics;
using RoundedBoxView.Forms.Plugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace RoundedBoxView.Forms.Plugin.Droid
{
    /// <summary>
    /// Source from https://gist.github.com/rudyryk/8cbe067a1363b45351f6
    /// </summary>
    public class RoundedBoxViewRenderer : BoxRenderer
    {
        public static void Init() { }

            protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
            {
                base.OnElementChanged(e);

                SetWillNotDraw(false);

                Invalidate();
            }

            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);

                if (e.PropertyName == Abstractions.RoundedBoxView.CornerRadiusProperty.PropertyName)
                {
                    Invalidate();
                }
            }

            public override void Draw(Canvas canvas)
            {
                var roundedBoxView = Element as Abstractions.RoundedBoxView;

                if (roundedBoxView == null)
                    return;

                var rect = new Rect();

                var paint = new Paint
                {
                    Color = roundedBoxView.BackgroundColor.ToAndroid(),
                    AntiAlias = true,
                };

                GetDrawingRect(rect);

                var radius = (float)(rect.Width() / roundedBoxView.Width * roundedBoxView.CornerRadius);

                canvas.DrawRoundRect(new RectF(rect), radius, radius, paint);
            }
        }
}