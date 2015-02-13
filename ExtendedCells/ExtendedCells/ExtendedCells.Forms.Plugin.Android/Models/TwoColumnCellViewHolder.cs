using Android.Widget;

namespace ExtendedCells.Forms.Plugin.Android.Models
{
  /// <summary>
  /// http://blog.xamarin.com/creating-highly-performant-smooth-scrolling-android-listviews/
  /// </summary>
  public class TwoColumnCellViewHolder : Java.Lang.Object
  {
    public TextView LeftTextView { get; set; }
    public TextView LeftDetailTextView { get; set; }
    public TextView RightTextView { get; set; }
    public TextView RightDetailTextView { get; set; }
  }
}