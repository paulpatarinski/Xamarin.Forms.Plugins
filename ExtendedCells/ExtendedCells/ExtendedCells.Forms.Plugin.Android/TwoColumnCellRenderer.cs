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
  ///   TwoColumn Cell renderer for Android
  /// </summary>
  public class TwoColumnCellRenderer : ViewCellRenderer
  {
    /// <summary>
    /// </summary>
    public static void Init()
    {
    }

    /// <summary>
    ///   Returns the View to render
    /// </summary>
    /// <param name="item"></param>
    /// <param name="convertView"></param>
    /// <param name="parent"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
    {
      var formsControl = (TwoColumnCell) item;
      TwoColumnCellViewHolder viewHolder = null;

      var view = (TableLayout) convertView;

      if (view != null)
      {
        viewHolder = view.Tag as TwoColumnCellViewHolder;
      }
      if (viewHolder == null)
      {
        viewHolder = new TwoColumnCellViewHolder
        {
          LeftTextView = new TextView(context),
          LeftDetailTextView = new TextView(context),
          RightTextView = new TextView(context),
          RightDetailTextView = new TextView(context) 
        };

        view = new TableLayout(context)
        {
          StretchAllColumns = true,
          LayoutParameters =
            new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
        };

        view.AddView(CreateRow(context, viewHolder.LeftTextView, viewHolder.RightTextView));
        view.AddView(CreateRow(context, viewHolder.LeftDetailTextView, viewHolder.RightDetailTextView));

        view.Tag = viewHolder;
      }

      ApplyFormsControlValuesToNativeControl(viewHolder, formsControl);

      return view;
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

    private static void ApplyFormsControlValuesToNativeControl(TwoColumnCellViewHolder viewHolder,
      TwoColumnCell formsControl)
    {
      viewHolder.LeftTextView.Text = formsControl.LeftText;

      if (formsControl.LeftTextFont.FontSize != 0.0)
        viewHolder.LeftTextView.TextSize = (float) formsControl.LeftTextFont.FontSize;

      viewHolder.LeftDetailTextView.Text = formsControl.LeftDetail;
      
      if (formsControl.LeftDetailFont.FontSize != 0.0)
        viewHolder.LeftDetailTextView.TextSize = (float) formsControl.LeftDetailFont.FontSize;

      viewHolder.RightTextView.Text = formsControl.RightText;
      
      if (formsControl.RightTextFont.FontSize != 0.0)
        viewHolder.RightTextView.TextSize = (float) formsControl.RightTextFont.FontSize;

      viewHolder.RightDetailTextView.Text = formsControl.RightDetail;

      if (formsControl.RightDetailFont.FontSize != 0.0)
        viewHolder.RightDetailTextView.TextSize = (float) formsControl.RightDetailFont.FontSize;
    }
  }
}