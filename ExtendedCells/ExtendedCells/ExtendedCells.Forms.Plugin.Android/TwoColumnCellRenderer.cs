using Android.Content;
using Android.Views;
using Android.Widget;
using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.Android;
using ExtendedCells.Forms.Plugin.Android.ExtensionsMethods;
using ExtendedCells.Forms.Plugin.Android.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof (TwoColumnCell), typeof (TwoColumnCellRenderer))]

namespace ExtendedCells.Forms.Plugin.Android
{
    /// <summary>
    /// TwoColumn Cell renderer for Android
    /// </summary>
    public class TwoColumnCellRenderer : CellRenderer
    {
        public static void Init()
        {
        }

        public TwoColumnTableLayout View { get; set; }

        protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
        {
            if ((View = convertView as TwoColumnTableLayout) == null)
            {
                View = new TwoColumnTableLayout(context)
                {
                    LeftTextView = new TextView(context),
                    LeftDetailTextView = new TextView(context),
                    RightTextView = new TextView(context),
                    RightDetailTextView = new TextView(context)
                };

                View.AddView(CreateRow(context, View.LeftTextView, View.RightTextView));
                View.AddView(CreateRow(context, View.LeftDetailTextView, View.RightDetailTextView));
            }

            var twoColumnCell = (TwoColumnCell) Cell;

            View.LeftTextView.UpdateFromFormsControl(twoColumnCell.LeftText,twoColumnCell.LeftTextColor, twoColumnCell.LeftTextFont);
            View.LeftDetailTextView.UpdateFromFormsControl(twoColumnCell.LeftDetail,twoColumnCell.LeftDetailColor, twoColumnCell.LeftDetailFont);
            View.RightTextView.UpdateFromFormsControl(twoColumnCell.RightText,twoColumnCell.RightTextColor, twoColumnCell.RightTextFont);
            View.RightDetailTextView.UpdateFromFormsControl(twoColumnCell.RightDetail,twoColumnCell.RightDetailColor, twoColumnCell.RightDetailFont);

            return View;
        }

        private static TableRow CreateRow(Context context, TextView leftTextView, TextView rightTextView)
        {
            var tableRow = new TableRow(context);

            tableRow.AddView(WrapTextViewInFrameLayout(context, leftTextView));
            tableRow.AddView(WrapTextViewInFrameLayout(context, rightTextView));

            return tableRow;
        }

        private static FrameLayout WrapTextViewInFrameLayout(Context context, TextView textView)
        {
            var frameLayout = new FrameLayout(context);
            frameLayout.AddView(textView);
            return frameLayout;
        }
    }
}