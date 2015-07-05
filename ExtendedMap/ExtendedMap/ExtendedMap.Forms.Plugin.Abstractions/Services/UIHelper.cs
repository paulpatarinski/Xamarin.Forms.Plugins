using System;
using Xamarin.Forms;
using SVG.Forms.Plugin.Abstractions;
using System.Reflection;
using ExtendedMap.Forms.Plugin.Abstractions.Models;

namespace ExtendedMap.Forms.Plugin.Abstractions.Services
{
	public class UIHelper
	{
		public ContentView CreateImageButton (string buttonImage, double height, double width,
			Action tappedCallback)
		{
			var grid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					},
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					},

				},
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.Center,
				RowSpacing = 5
			};

			var navImage = new SvgImage {
				SvgPath = string.Format ("ExtendedMap.Forms.Plugin.Abstractions.Images.{0}", buttonImage),
				SvgAssembly = typeof(CustomMapContentView).GetTypeInfo ().Assembly,
				HorizontalOptions = LayoutOptions.Center,
				HeightRequest = height,
				WidthRequest = width
			};

			grid.GestureRecognizers.Add (new TapGestureRecognizer{ Command = new Command (tappedCallback) });

			grid.Children.Add (navImage, 0, 0);

			return new ContentView { Content = grid };
		}

		public ContentView CreateImageButton (string buttonImage, string buttonText, double height, double width,
			Action<View, Object> tappedCallback)
		{
			var grid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					},

				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					},

				},
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.Center,
				RowSpacing = 5
			};

			var navImageGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					}
				},
				ColumnDefinitions = new ColumnDefinitionCollection {

					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					},


				}
			};

			var navImage = new SvgImage {
				SvgPath = string.Format ("ExtendedMap.Forms.Plugin.Abstractions.Images.{0}", buttonImage),
				SvgAssembly = typeof(CustomMapContentView).GetTypeInfo ().Assembly,
				HeightRequest = height,
				WidthRequest = width
			};

			grid.GestureRecognizers.Add (new TapGestureRecognizer (tappedCallback));

			navImageGrid.Children.Add (navImage, 0, 0);

			var label = new Label {
				Text = buttonText,
				Font = Font.SystemFontOfSize (14),
				TextColor = Colors.DarkBlue,
				HorizontalOptions = LayoutOptions.Center
			};

			grid.Children.Add (navImageGrid, 0, 0);
			grid.Children.Add (label, 0, 1);

			return new ContentView { Content = grid };
		}

	}
}

