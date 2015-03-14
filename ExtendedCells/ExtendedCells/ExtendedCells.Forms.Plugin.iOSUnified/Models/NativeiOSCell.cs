using System;
using UIKit;
using Foundation;
using ExtendedCells.Forms.Plugin.Abstractions;
using Xamarin.Forms.Platform.iOS;
using ExtendedCells.Forms.Plugin.iOSUnified;

namespace ExtendedCells.Forms.Plugin.Models
{
	/// <summary>
	/// Sample of a custom cell layout, taken from the iOS docs at
	/// http://developer.xamarin.com/guides/ios/user_interface/tables/part_3_-_customizing_a_table's_appearance/
	/// </summary>
	public class NativeiOSCell : UITableViewCell
	{
		UILabel leftTextUILabel, leftDetailUILabel, rightTextUILabel, rightDetailUILabel;

		ExtendedTextCell extendedTextCell;

		public NativeiOSCell (NSString cellId, ExtendedTextCell extendedTextCell) : base (UITableViewCellStyle.Default, cellId)
		{
			this.extendedTextCell = extendedTextCell;
			SelectionStyle = UITableViewCellSelectionStyle.Default;

			leftTextUILabel = new UILabel ();
			leftDetailUILabel = new UILabel ();
			rightTextUILabel = new UILabel ();
			rightDetailUILabel = new UILabel ();

			ContentView.Add (leftTextUILabel);
			ContentView.Add (rightTextUILabel);

			if (!string.IsNullOrEmpty (extendedTextCell.LeftDetail) || !string.IsNullOrEmpty (extendedTextCell.RightDetail)) {
				ContentView.Add (leftDetailUILabel);
				ContentView.Add (rightDetailUILabel);
			}
		}

		public void UpdateCell (ExtendedTextCell extendedTextCell)
		{
			this.extendedTextCell = extendedTextCell;
			ContentView.BackgroundColor = extendedTextCell.BackgroundColor.ToUIColor ();

			leftTextUILabel.UpdateFromFormsControl (extendedTextCell.LeftText, extendedTextCell.LeftTextAlignment, extendedTextCell.LeftTextColor, extendedTextCell.LeftTextFont);
			leftDetailUILabel.UpdateFromFormsControl (extendedTextCell.LeftDetail, extendedTextCell.LeftDetailAlignment, extendedTextCell.LeftDetailColor, extendedTextCell.LeftDetailFont);
			rightTextUILabel.UpdateFromFormsControl (extendedTextCell.RightText, extendedTextCell.RightTextAlignment, extendedTextCell.RightTextColor, extendedTextCell.RightTextFont);
			rightDetailUILabel.UpdateFromFormsControl (extendedTextCell.RightDetail, extendedTextCell.RightDetailAlignment, extendedTextCell.RightDetailColor, extendedTextCell.RightDetailFont);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			var widthWithMargins = ContentView.Bounds.Width- (nfloat)(extendedTextCell.Thickness.Left + extendedTextCell.Thickness.Right);
			var leftColumnXWithMargin = ContentView.Bounds.X + (nfloat)(extendedTextCell.Thickness.Left);

			ContentView.Bounds = new CoreGraphics.CGRect(leftColumnXWithMargin,ContentView.Bounds.Y, widthWithMargins, ContentView.Bounds.Height);

			var leftColumnWidth = (float)(ContentView.Bounds.Width * extendedTextCell.LeftColumnWidth.Value);
			var rightColumnWidth = (float)(ContentView.Bounds.Width * extendedTextCell.RightColumnWidth.Value);
			var rightColumnX = leftColumnWidth + leftColumnXWithMargin;

			var firstRowHeight = ContentView.Bounds.Height / 2;
			var secondRowHeight = ContentView.Bounds.Height / 2;


			if (!string.IsNullOrEmpty (extendedTextCell.LeftDetail) || !string.IsNullOrEmpty (extendedTextCell.LeftDetail)) {

				leftTextUILabel.Frame = new CoreGraphics.CGRect (leftColumnXWithMargin, 0, leftColumnWidth, firstRowHeight);
				leftDetailUILabel.Frame = new CoreGraphics.CGRect (leftColumnXWithMargin, firstRowHeight, leftColumnWidth, secondRowHeight);

				rightTextUILabel.Frame = new CoreGraphics.CGRect (rightColumnX, 0, rightColumnWidth, firstRowHeight);
				rightDetailUILabel.Frame = new CoreGraphics.CGRect (rightColumnX, firstRowHeight, rightColumnWidth, secondRowHeight);

			} else {
				leftTextUILabel.Frame = new CoreGraphics.CGRect (leftColumnXWithMargin, 0, leftColumnWidth, ContentView.Bounds.Height);
				rightTextUILabel.Frame = new CoreGraphics.CGRect (rightColumnX, 0, rightColumnWidth, ContentView.Bounds.Height);
			}
		}
	}

}
