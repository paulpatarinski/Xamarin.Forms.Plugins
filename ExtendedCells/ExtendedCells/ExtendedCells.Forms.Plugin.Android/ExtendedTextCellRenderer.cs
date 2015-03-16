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

[assembly: ExportRenderer (typeof(ExtendedTextCell), typeof(ExtendedTextCellRenderer))]

namespace ExtendedCells.Forms.Plugin.Android
{
	/// <summary>
	///   Extended Text Cell renderer for Android
	/// </summary>
	public class ExtendedTextCellRenderer : CellRenderer
	{
		/// <summary>
		///   Call this method to make sure the assembly gets loaded
		/// </summary>
		public static void Init ()
		{
		}

		private ExtendedCellTableLayout _view;

		/// <summary>
		///   This method returns the View (Controls Layout) for the current Cell
		/// </summary>
		/// <param name="item"></param>
		/// <param name="convertView"></param>
		/// <param name="parent"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		protected override View GetCellCore (Cell item, View convertView, ViewGroup parent, Context context)
		{
			var extendedTextCell = (ExtendedTextCell)Cell;

			if ((_view = convertView as ExtendedCellTableLayout) == null) {
				_view = new ExtendedCellTableLayout (context) {
					LeftTextView = new TextView (context),
					LeftDetailTextView = new TextView (context),
					RightTextView = new TextView (context),
					RightDetailTextView = new TextView (context)
				};

				if (extendedTextCell.LeftText != null || extendedTextCell.RightText != null)
					_view.AddView (CreateRow (context, _view.LeftTextView, _view.RightTextView, extendedTextCell.LeftColumnWidth, extendedTextCell.RightColumnWidth));

				if (extendedTextCell.LeftDetail != null || extendedTextCell.RightDetail != null)
					_view.AddView (CreateRow (context, _view.LeftDetailTextView, _view.RightDetailTextView, extendedTextCell.LeftColumnWidth, extendedTextCell.RightColumnWidth));
			}

			_view.SetBackgroundColor (extendedTextCell.BackgroundColor.ToAndroid ());
			_view.SetPadding ((int)extendedTextCell.Thickness.Left, (int)extendedTextCell.Thickness.Top, (int)extendedTextCell.Thickness.Right, (int)extendedTextCell.Thickness.Bottom);

			if (extendedTextCell.LeftText != null)
				_view.LeftTextView.UpdateFromFormsControl (extendedTextCell.LeftText, extendedTextCell.LeftTextColor,
					extendedTextCell.LeftTextFont, extendedTextCell.LeftTextAlignment);

			if (extendedTextCell.LeftDetail != null)
				_view.LeftDetailTextView.UpdateFromFormsControl (extendedTextCell.LeftDetail, extendedTextCell.LeftDetailColor,
					extendedTextCell.LeftDetailFont, extendedTextCell.LeftDetailAlignment);

			if (extendedTextCell.RightText != null)
				_view.RightTextView.UpdateFromFormsControl (extendedTextCell.RightText, extendedTextCell.RightTextColor,
					extendedTextCell.RightTextFont, extendedTextCell.RightTextAlignment);

			if (extendedTextCell.RightDetail != null)
				_view.RightDetailTextView.UpdateFromFormsControl (extendedTextCell.RightDetail, extendedTextCell.RightDetailColor,
					extendedTextCell.RightDetailFont, extendedTextCell.RightDetailAlignment);

			return _view;
		}

		private static TableRow CreateRow (Context context, View leftTextView, View rightTextView, GridLength leftColumnWidth, GridLength rightColumnWidth)
		{
			var tableRow = new TableRow (context);
			var linearLayout = new LinearLayout (context) { WeightSum = (float)1.0 };

			//This is a little counter intuitive, but the Left Text View needs to be set to the Right Column Width 
			var leftTextViewLayout = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent,
				                            ViewGroup.LayoutParams.MatchParent) { Weight = (float)rightColumnWidth.Value };

			leftTextView.LayoutParameters = leftTextViewLayout;
      
			linearLayout.AddView (leftTextView);

			var rightTextViewLayout = new LinearLayout.LayoutParams (ViewGroup.LayoutParams.MatchParent,
				                             ViewGroup.LayoutParams.MatchParent) { Weight = (float)leftColumnWidth.Value };

			rightTextView.LayoutParameters = rightTextViewLayout;
      
			linearLayout.AddView (rightTextView);
      
			tableRow.AddView (linearLayout);

			return tableRow;
		}
	}
}