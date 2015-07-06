using Xamarin.Forms;
using ExtendedMap.Forms.Plugin.Abstractions.Services;
using System;

namespace ExtendedMap.Forms.Plugin.Abstractions
{
	public class Footer : ContentView
	{
		public Footer (ExtendedMap map, double pageHeight, double minimizedFooterY, double expandedFooterY)
		{
			_extendedMap = map;
			_uiHelper = new UIHelper ();
			_pageHeight = pageHeight;
			_minimizedFooterY = minimizedFooterY;
			_expandedFooterY = expandedFooterY;
			FooterMode = FooterMode.Hidden;

			var footerLayout = new RelativeLayout ();

			footerLayout.Children.Add (
				new FooterMaster(_extendedMap, _uiHelper, this),
				Constraint.RelativeToParent ((parent) => (parent.Width * 0)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0)),
				Constraint.RelativeToParent ((parent) => (parent.Width * 1)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0.15))
			);

			footerLayout.Children.Add (
				new FooterDetail(_uiHelper, _extendedMap, this),
				Constraint.RelativeToParent ((parent) => (parent.Width * 0)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0.149)),
				Constraint.RelativeToParent ((parent) => (parent.Width * 1)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 1))
			);

			Content = footerLayout;
		}

		ExtendedMap _extendedMap;
		UIHelper _uiHelper;
		private double _pageHeight;
		private double _minimizedFooterY;
		private double _expandedFooterY;
		public event EventHandler<FooterMode> FooterModeChanged;

		private const uint COLLAPSE_ANIMATION_SPEED = 400;
		private const uint EXPAND_ANIMATION_SPEED = 400;

		private FooterMode _footerMode;

		public FooterMode FooterMode {
			get { return _footerMode; }
			set {
				_footerMode = value;

				switch (value) {
				case FooterMode.Expanded:
					ExpandFooter ();
					break;
				case FooterMode.Minimized:
					MinimizeFooter ();
					break;
				default:
					HideFooter ();
					break;
				}

				if(FooterModeChanged != null)
				{
					FooterModeChanged (this, value);
				}
			}
		}

	 

		private void HideFooter ()
		{
			var footerOldBounds = this.Bounds;
			var footerNewBounds = new Rectangle (footerOldBounds.X, _pageHeight, footerOldBounds.Width, footerOldBounds.Height);

			this.LayoutTo (footerNewBounds, EXPAND_ANIMATION_SPEED, Easing.SinIn);
		}

		private void ExpandFooter ()
		{
			var footerOldBounds = this.Bounds;
			var footerNewBounds = new Rectangle (footerOldBounds.X, _expandedFooterY, footerOldBounds.Width,
				footerOldBounds.Height);

			this.LayoutTo (footerNewBounds, EXPAND_ANIMATION_SPEED, Easing.SinIn);

			_extendedMap.CenterOnPosition = _extendedMap.SelectedPin.Position;
		}

		private void MinimizeFooter ()
		{
			var footerOldBounds = this.Bounds;
			var footerNewBounds = new Rectangle (footerOldBounds.X, _minimizedFooterY, footerOldBounds.Width,
				footerOldBounds.Height);

			this.LayoutTo (footerNewBounds, COLLAPSE_ANIMATION_SPEED, Easing.SinIn);

			_extendedMap.CenterOnPosition = _extendedMap.SelectedPin.Position;
		}


		public void ToogleFooter ()
		{
			FooterMode = FooterMode == FooterMode.Expanded ? FooterMode.Minimized : FooterMode.Expanded;
		}

	}
}

