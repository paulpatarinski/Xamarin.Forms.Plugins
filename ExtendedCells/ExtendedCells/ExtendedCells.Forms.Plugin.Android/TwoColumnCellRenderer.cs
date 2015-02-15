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
  ///   TwoColumn Cell renderer for Android
  /// </summary>
  public class TwoColumnCellRenderer : CellRenderer
  {
    /// <summary>
    ///   Call this method to make sure the assembly gets loaded
    /// </summary>
    public static void Init()
    {
    }

    private TwoColumnTableLayout _view;

    /// <summary>
    ///   This method returns the View (Controls Layout) for the current Cell
    /// </summary>
    /// <param name="item"></param>
    /// <param name="convertView"></param>
    /// <param name="parent"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    protected override View GetCellCore(Cell item, View convertView, ViewGroup parent, Context context)
    {
      var twoColumnCell = (TwoColumnCell) Cell;

      if ((_view = convertView as TwoColumnTableLayout) == null)
      {
        _view = new TwoColumnTableLayout(context)
        {
          LeftTextView = new TextView(context),
          LeftDetailTextView = new TextView(context),
          RightTextView = new TextView(context),
          RightDetailTextView = new TextView(context)
        };

        if (twoColumnCell.LeftText != null || twoColumnCell.RightText != null)
          _view.AddView(CreateRow(context, _view.LeftTextView, _view.RightTextView));

        if (!string.IsNullOrEmpty(twoColumnCell.LeftDetail) || !string.IsNullOrEmpty(twoColumnCell.RightDetail))
          _view.AddView(CreateRow(context, _view.LeftDetailTextView, _view.RightDetailTextView));
      }

      if (twoColumnCell.LeftText != null)
        _view.LeftTextView.UpdateFromFormsControl(twoColumnCell.LeftText, twoColumnCell.LeftTextColor,
        twoColumnCell.LeftTextFont, twoColumnCell.LeftTextAlignment);

      if (twoColumnCell.LeftDetail != null)
        _view.LeftDetailTextView.UpdateFromFormsControl(twoColumnCell.LeftDetail, twoColumnCell.LeftDetailColor,
          twoColumnCell.LeftDetailFont, twoColumnCell.LeftDetailAlignment);

      if (twoColumnCell.RightText != null)
        _view.RightTextView.UpdateFromFormsControl(twoColumnCell.RightText, twoColumnCell.RightTextColor,
        twoColumnCell.RightTextFont, twoColumnCell.RightTextAlignment);

      if (twoColumnCell.RightDetail != null)
        _view.RightDetailTextView.UpdateFromFormsControl(twoColumnCell.RightDetail, twoColumnCell.RightDetailColor,
          twoColumnCell.RightDetailFont, twoColumnCell.RightDetailAlignment);

      return _view;
    }

    private static TableRow CreateRow(Context context, View leftTextView, View rightTextView)
    {
      var tableRow = new TableRow(context);

      tableRow.AddView(leftTextView.WrapInFrameLayout(context));
      tableRow.AddView(rightTextView.WrapInFrameLayout(context));

      return tableRow;
    }
  }
}