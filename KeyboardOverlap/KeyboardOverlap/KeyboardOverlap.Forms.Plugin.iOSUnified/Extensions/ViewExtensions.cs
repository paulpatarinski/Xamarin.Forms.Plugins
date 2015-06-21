using System;
using UIKit;
using Foundation;
using CoreGraphics;

namespace KeyboardOverlap.Forms.Plugin.iOSUnified
{
	public static class ViewExtensions
	{
		/// <summary>
		/// Find the first responder in the <paramref name="view"/>'s subview hierarchy
		/// </summary>
		/// <param name="view">
		/// A <see cref="UIView"/>
		/// </param>
		/// <returns>
		/// A <see cref="UIView"/> that is the first responder or null if there is no first responder
		/// </returns>
		public static UIView FindFirstResponder (this UIView view)
		{
			if (view.IsFirstResponder) {
				return view;
			}
			foreach (UIView subView in view.Subviews) {
				var firstResponder = subView.FindFirstResponder ();
				if (firstResponder != null)
					return firstResponder;
			}
			return null;
		}

		/// <summary>
		/// Returns the new view Bottom (Y + Height) coordinates relative to the rootView
		/// </summary>
		/// <returns>The view relative bottom.</returns>
		/// <param name="view">View.</param>
		/// <param name="rootView">Root view.</param>
		public static double GetViewRelativeBottom (this UIView view, UIView rootView)
		{
			var viewRelativeCoordinates = rootView.ConvertPointFromView (view.Frame.Location, view);
			var activeViewRoundedY = Math.Round (viewRelativeCoordinates.Y, 2);

			return activeViewRoundedY + view.Frame.Height;
		}

		/// <summary>
		/// Determines if the UIView is overlapped by the keyboard
		/// </summary>
		/// <returns><c>true</c> if is keyboard overlapping the specified activeView rootView keyboardFrame; otherwise, <c>false</c>.</returns>
		/// <param name="activeView">Active view.</param>
		/// <param name="rootView">Root view.</param>
		/// <param name="keyboardFrame">Keyboard frame.</param>
		public static bool IsKeyboardOverlapping (this UIView activeView, UIView rootView, CGRect keyboardFrame)
		{
			var activeViewBottom = activeView.GetViewRelativeBottom (rootView);
			var pageHeight = rootView.Frame.Height;
			var keyboardHeight = keyboardFrame.Height;

			var isOverlapping = activeViewBottom >= (pageHeight - keyboardHeight);

			return isOverlapping;
		}
	}
}