using System;
using System.Reflection;
using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using ExtendedMap.Forms.Plugin.Abstractions.Services;
using SVG.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace ExtendedMap.Forms.Plugin.Abstractions
{
	public class CustomMapContentView : ContentView
	{
		public CustomMapContentView (ExtendedMap extendedMap)
		{
			_extendedMap = extendedMap;

			_mapGrid = new RelativeLayout {BindingContext = this};

			Content = _mapGrid;
		}

		private double _pageHeight;
		//		private readonly Grid _mapGrid;
		private readonly RelativeLayout _mapGrid;
		private readonly ExtendedMap _extendedMap;
		public Footer Footer;

//		private View _mapGridFooterRow {
//			get {
//				var footerRow = _mapGrid.Children [1];
//
//				return footerRow;
//			}
//		}

		protected override void OnSizeAllocated (double width, double height)
		{
			//If the pageSize values have not been set yet, set them
			if (Math.Abs (_pageHeight) < 0.001 && height > 0) {
				_pageHeight = Bounds.Height;
				const double collapsedMapHeight = 0.37;
				const double expandedMapHeight = 0.86;
				const double expandedFooterHeight = 0.63;

				var minimizedFooterY = _pageHeight * expandedMapHeight;
				var expandedFooterY = _pageHeight * collapsedMapHeight;

				_mapGrid.Children.Add (
					_extendedMap,
					Constraint.RelativeToParent ((parent) => {
						return (parent.Width * 0);
					}),
					Constraint.RelativeToParent ((parent) => {
						return (parent.Height * 0);
					}),
					Constraint.RelativeToParent ((parent) => {
						return (parent.Width * 1);
					}),
					Constraint.RelativeToParent ((parent) => {
						return (parent.Height * 1);
					})
				);

				Footer = new Footer (_extendedMap, _pageHeight, minimizedFooterY, expandedFooterY);

				_mapGrid.Children.Add (
					Footer,
					Constraint.RelativeToParent ((parent) => {
						return (parent.Width * 0);
					}),
					Constraint.RelativeToParent ((parent) => {
						return (parent.Height * expandedMapHeight);
					}),
					Constraint.RelativeToParent ((parent) => {
						return (parent.Width * 1);
					}),
					Constraint.RelativeToParent ((parent) => {
						return (parent.Height * 1);
					})
				);
			
				Footer.FooterMode = FooterMode.Hidden;
			}

			base.OnSizeAllocated (width, height);
		}
//
	}

	public enum FooterMode
	{
		Expanded,
		Minimized,
		Hidden
	}
}