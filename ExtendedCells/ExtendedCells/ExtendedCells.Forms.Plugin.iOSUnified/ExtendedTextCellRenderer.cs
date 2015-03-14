using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedCells.Forms.Plugin.iOSUnified;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Foundation;
using UIKit;
using System;
using ExtendedCells.Forms.Plugin.Models;

[assembly: ExportRenderer (typeof(ExtendedTextCell), typeof(ExtendedTextCellRenderer))]
namespace ExtendedCells.Forms.Plugin.iOSUnified
{
	/// <summary>
	/// SVG Renderer
	/// </summary>
	public class ExtendedTextCellRenderer : CellRenderer
	{
		static NSString rid = new NSString ("NativeCell");

		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		public static void Init ()
		{
		}

		public override UITableViewCell GetCell (Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var formsControl = (ExtendedTextCell)item;
		
			var nativeControl = reusableCell as NativeiOSCell;
			
			if (nativeControl == null) {
				nativeControl = new NativeiOSCell (rid, formsControl);
			}
						
			nativeControl.UpdateCell (formsControl);
		
			return nativeControl;
		}
	}
}
