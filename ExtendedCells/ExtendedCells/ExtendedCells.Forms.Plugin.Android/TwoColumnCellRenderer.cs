using Android.Content;
using Android.Views;
using Android.Widget;
using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.Android;
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
                View = new TwoColumnTableLayout(context);

                View.LeftTextView = new TextView(context);
                View.LeftDetailTextView = new TextView(context);
                View.RightTextView = new TextView(context);
                View.RightDetailTextView = new TextView(context);

                View.AddView(CreateRow(context, View.LeftTextView, View.RightTextView));
                View.AddView(CreateRow(context, View.LeftDetailTextView, View.RightDetailTextView));
            }

            UpdateLeftTextView();
            UpdateLeftDetailTextView();
            UpdateRightTextView();
            UpdateRightDetailTextView();

            return View;
        }

        private void UpdateLeftTextView()
        {
            var twoColumnCell = Cell as TwoColumnCell;

            if (twoColumnCell != null)
            {
                View.LeftTextView.Text = twoColumnCell.LeftText;
                View.LeftTextView.SetTextColor(twoColumnCell.LeftTextColor.ToAndroid(Color.Default));

                if (twoColumnCell.LeftTextFont.FontSize != 0.0)
                    View.LeftTextView.TextSize = (float) twoColumnCell.LeftTextFont.FontSize;
            }
        }

        private void UpdateLeftDetailTextView()
        {
            var twoColumnCell = Cell as TwoColumnCell;

            if (twoColumnCell != null)
            {
                View.LeftDetailTextView.Text = twoColumnCell.LeftDetail;
                View.LeftDetailTextView.SetTextColor(twoColumnCell.LeftDetailColor.ToAndroid(Color.Default));

                if (twoColumnCell.LeftDetailFont.FontSize != 0.0)
                    View.LeftDetailTextView.TextSize = (float) twoColumnCell.LeftTextFont.FontSize;
            }
        }

        private void UpdateRightTextView()
        {
            var twoColumnCell = Cell as TwoColumnCell;

            if (twoColumnCell != null)
            {
                View.RightTextView.Text = twoColumnCell.RightText;
                View.RightTextView.SetTextColor(twoColumnCell.RightTextColor.ToAndroid(Color.Default));
                
                if (twoColumnCell.RightTextFont.FontSize != 0.0)
                    View.RightTextView.TextSize = (float) twoColumnCell.RightTextFont.FontSize;
            }
        }

        private void UpdateRightDetailTextView()
        {
            var twoColumnCell = Cell as TwoColumnCell;

            if (twoColumnCell != null)
            {
                View.RightDetailTextView.Text = twoColumnCell.RightDetail;
                View.RightDetailTextView.SetTextColor(twoColumnCell.RightDetailColor.ToAndroid(Color.Default));

                if (twoColumnCell.RightDetailFont.FontSize != 0.0)
                    View.RightDetailTextView.TextSize = (float) twoColumnCell.RightDetailFont.FontSize;
            }
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