using Android.Content;
using Android.Views;
using Android.Widget;

namespace ExtendedCells.Forms.Plugin.Android.Models
{
    public class ExtendedCellTableLayout : TableLayout
    {
        public ExtendedCellTableLayout(Context context)
            : base(context)
        {
            StretchAllColumns = true;
            LayoutParameters =
                new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
        }

        public TextView LeftTextView { get; set; }
        public TextView LeftDetailTextView { get; set; }
        public TextView RightTextView { get; set; }
        public TextView RightDetailTextView { get; set; }
    }
}