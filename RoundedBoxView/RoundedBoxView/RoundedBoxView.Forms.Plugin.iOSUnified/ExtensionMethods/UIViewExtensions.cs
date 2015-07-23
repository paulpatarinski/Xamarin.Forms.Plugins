using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System;

namespace RoundedBoxView.Forms.Plugin.iOSUnified.ExtensionMethods
{
	public static class UIViewExtensions
	{
		public static void UpdateFrom(this UIView nativeControl, RoundedBoxView.Forms.Plugin.Abstractions.RoundedBoxView formsControl, string propertyChanged = null )
		{
			if (nativeControl == null || formsControl == null)
				return;
			
			if(propertyChanged == null)
			{
				nativeControl.Layer.MasksToBounds = true;
				nativeControl.Layer.CornerRadius = (float) formsControl.CornerRadius;
				nativeControl.UpdateBorder (formsControl.BorderColor, formsControl.BorderThickness);
			}
			else
			{
				if (propertyChanged == Abstractions.RoundedBoxView.CornerRadiusProperty.PropertyName)
				{
					nativeControl.Layer.CornerRadius = (float) formsControl.CornerRadius;
				}

				if (propertyChanged == Abstractions.RoundedBoxView.BorderColorProperty.PropertyName) 
				{
					nativeControl.UpdateBorder (formsControl.BorderColor, formsControl.BorderThickness);
				}

				if (propertyChanged == Abstractions.RoundedBoxView.BorderThicknessProperty.PropertyName) 
				{
					nativeControl.UpdateBorder (formsControl.BorderColor, formsControl.BorderThickness);
				}
			}
		}

		public static void UpdateBorder(this UIView nativeControl, Color color, int thickness)
		{
			nativeControl.Layer.BorderColor = color.ToCGColor();
			nativeControl.Layer.BorderWidth = (nfloat)thickness;
		}
	}
}