using Android.Content;
using Android.Views;
using Android.Widget;

namespace ExtendedCells.Forms.Plugin.Android.ExtensionsMethods
{
  public static class ViewExtensions
  {
    public static FrameLayout WrapInFrameLayout(this View viewToWrap, Context context)
    {
      var frameLayout = new FrameLayout(context);

      frameLayout.AddView(viewToWrap);

      return frameLayout;
    }
  }
}