using System.Resources;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(TwoColumnCell), typeof(TwoColumnCellRenderer))]

namespace ExtendedCells.Forms.Plugin.Android
{
  public class TwoColumnCellRenderer : ViewCellRenderer
  {
    public static void Init()
    {
    }

    protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
    {
      var x = (TwoColumnCell) item;

      var view = convertView;

      if (view == null)
      {
        // no view to re-use, create new
        var activity = context as Activity;
        
        var test = Resource.Layout.TwoColumnCellNative;
        //var testLayout = Resource.Layout.TestLayout;
        if (activity != null)
          view = activity.LayoutInflater.Inflate(test, null);
      }
      else
      {
        // re-use, clear image
        // doesn't seem to help
        //view.FindViewById<ImageView> (Resource.Id.Image).Drawable.Dispose ();
      }

      view.FindViewById<TextView>(Resource.Id.LeftText).Text = x.LeftText;
      view.FindViewById<TextView>(Resource.Id.LeftDetail).Text = x.LeftDetail;

      //// grab the old image and dispose of it
      //// TODO: optimize if the image is the *same* and we want to just keep it
      //if (view.FindViewById<ImageView>(Resource.Id.Image).Drawable != null)
      //{
      //  using (var image = view.FindViewById<ImageView>(Resource.Id.Image).Drawable as BitmapDrawable)
      //  {
      //    if (image != null)
      //    {
      //      if (image.Bitmap != null)
      //      {
      //        //image.Bitmap.Recycle ();
      //        image.Bitmap.Dispose();
      //      }
      //    }
      //  }
      //}

      //// If a new image is required, display it
      //if (!String.IsNullOrWhiteSpace(x.ImageFilename))
      //{
      //  context.Resources.GetBitmapAsync(x.ImageFilename).ContinueWith((t) =>
      //  {
      //    var bitmap = t.Result;
      //    if (bitmap != null)
      //    {
      //      view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(bitmap);
      //      bitmap.Dispose();
      //    }
      //  }, TaskScheduler.FromCurrentSynchronizationContext());

      //}
      //else
      //{
      //  // clear the image
      //  view.FindViewById<ImageView>(Resource.Id.Image).SetImageBitmap(null);
      //}

      return view;
    }

  }
}