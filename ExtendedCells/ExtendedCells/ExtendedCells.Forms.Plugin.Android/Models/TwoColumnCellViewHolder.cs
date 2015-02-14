using Android.Widget;
using Object = Java.Lang.Object;

namespace ExtendedCells.Forms.Plugin.Android.Models
{
  /// <summary>
  /// http://blog.xamarin.com/creating-highly-performant-smooth-scrolling-android-listviews/
  /// </summary>
  public class TwoColumnCellViewHolder : Object
  {
      public TextView LeftTextView;
      public TextView LeftDetailTextView;
      public TextView RightTextView;
      public TextView RightDetailTextView;

    
  }
}