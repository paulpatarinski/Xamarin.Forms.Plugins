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
		/// It is possible the Y value of a view is specified on its SuperView
		/// This method will traverse the hierarchy and return the View containing the positive Y 
		/// </summary>
		/// <returns>The view Y value.</returns>
		/// <param name="view">View.</param>
		public static CGRect GetFrameWithPositiveYValue (this UIView view)
		{
			return view.Frame.Y > 0 ? view.Frame : view.Superview.GetFrameWithPositiveYValue ();
		}

		public static double GetViewBottomEdgeY (this UIView view)
		{
			var activeViewFrame = view.GetFrameWithPositiveYValue ();
			return activeViewFrame.Y + activeViewFrame.Height;
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
			var activeViewFrame = activeView.GetFrameWithPositiveYValue ();
			var entryBottomEdge = activeViewFrame.Y + activeViewFrame.Height;
			var pageHeight = rootView.Frame.Height;
			var keyboardHeight = keyboardFrame.Height;

			var isOverlapping = entryBottomEdge >= (pageHeight - keyboardHeight);

			return isOverlapping;
		}


	}
}