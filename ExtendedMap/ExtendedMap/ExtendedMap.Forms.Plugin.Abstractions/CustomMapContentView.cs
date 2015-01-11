using System;
using System.Reflection;
using SVG.Forms.Plugin.Abstractions;
using Xamarin.Forms;

namespace ExtendedMap.Forms.Plugin.Abstractions
{
	public class CustomMapContentView : ContentView
	{
		public CustomMapContentView (ExtendedMap extendedMap)
		{
			_extendedMap = extendedMap;

			//The Heights of the rows are overwritten
			_mapGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition (), new RowDefinition ()
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					}
				}, RowSpacing = 0
			};

			//Bind the footer to the ShowFooter property
			_mapGrid.BindingContext = this;

			Content = _mapGrid;
		}

		private const uint COLLAPSE_ANIMATION_SPEED = 400;
		private const uint EXPAND_ANIMATION_SPEED = 400;
		private double _minimizedFooterY;
		private double _expandedFooterY;
		private double _pageHeight;
        private double _pageWidth;
        private Grid _mapGrid;
		private ExtendedMap _extendedMap;
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
			}
		}

		private View _mapGridFooterRow { get { return _mapGrid.Children [1]; } }

		private View _mapGridMapRow {
			get {
				return _mapGrid.Children [1];
			}
		}

		protected override void OnSizeAllocated (double width, double height)
		{
			//If the pageSize values have not been set yet, set them
			if (Math.Abs (_pageHeight) < 0.001 && height > 0) {
				_pageHeight = Bounds.Height;
				_pageWidth = Bounds.Width;
				const double collapsedMapHeight = 0.37;
				const double expandedMapHeight = 0.86;
				const double expandedFooterHeight = 0.63;

				_minimizedFooterY = _pageHeight * expandedMapHeight;
				_expandedFooterY = _pageHeight * collapsedMapHeight;

				var footerHeight = height * expandedFooterHeight;

				_mapGrid.RowDefinitions [0].Height = new GridLength (height * expandedMapHeight);
				_mapGrid.RowDefinitions [1].Height = new GridLength (footerHeight);

				_mapGrid.Children.Add (_extendedMap, 0, 0);
                _mapGrid.Children.Add(CreateFooter(footerHeight), 0, 1);

				Grid.SetRowSpan (_extendedMap, 2);

				_mapGridFooterRow.GestureRecognizers.Add (new TapGestureRecognizer ((view, obj) => ToogleFooter ()));

				FooterMode = FooterMode.Hidden;
			}

			base.OnSizeAllocated (width, height);
		}

		void ToogleFooter ()
		{
			FooterMode = FooterMode == FooterMode.Expanded ? FooterMode.Minimized : FooterMode.Expanded;
		}

		void HideFooter ()
		{
			var footerOldBounds = _mapGridFooterRow.Bounds;
			var footerNewBounds = new Rectangle (footerOldBounds.X, _pageHeight, footerOldBounds.Width, footerOldBounds.Height);

			_mapGridFooterRow.LayoutTo (footerNewBounds, EXPAND_ANIMATION_SPEED, Easing.SinIn);
		}

		void ExpandFooter ()
		{
			var footerOldBounds = _mapGridFooterRow.Bounds;
			var footerNewBounds = new Rectangle (footerOldBounds.X, _expandedFooterY, footerOldBounds.Width, footerOldBounds.Height);

			_mapGridFooterRow.LayoutTo (footerNewBounds, EXPAND_ANIMATION_SPEED, Easing.SinIn);

			_extendedMap.CameraFocusYOffset = 1000;
			_extendedMap.CenterOnPosition = _extendedMap.SelectedPin.Position;
		}

		void MinimizeFooter ()
		{
			var footerOldBounds = _mapGridFooterRow.Bounds;
			var footerNewBounds = new Rectangle (footerOldBounds.X, _minimizedFooterY, footerOldBounds.Width, footerOldBounds.Height);

			_mapGridFooterRow.LayoutTo (footerNewBounds, COLLAPSE_ANIMATION_SPEED, Easing.SinIn);

			_extendedMap.CameraFocusYOffset = 500;
			_extendedMap.CenterOnPosition = _extendedMap.SelectedPin.Position;
		}

		#region UI Creation

		ContentView CreateFooter (double footerHeight)
		{
			var footerMainGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (0.2, GridUnitType.Star)
					}, new RowDefinition {
						Height = new GridLength (0.8, GridUnitType.Star)
					},
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					}
				},
			};

			var footerMasterGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					},
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (0.025, GridUnitType.Star)
					}, new ColumnDefinition {
						Width = new GridLength (0.95, GridUnitType.Star)
					},
				},
				RowSpacing = 10, StyleId = "FooterGrid"
			};

			var footerGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					}
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (0.75, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (0.25, GridUnitType.Star)
					},
				},
				BackgroundColor = Color.White
			};


			var placeNameLabel = new Label {
				Text = "Pin Label Shows Here",
				TextColor = Color.Black,
			};

			Device.OnPlatform (iOS: () => placeNameLabel.Font = Font.SystemFontOfSize (20),
				Android: () => placeNameLabel.Font = Font.SystemFontOfSize (20),
				WinPhone: () => placeNameLabel.Font = Font.SystemFontOfSize (24));

			placeNameLabel.BindingContext = _extendedMap;

			placeNameLabel.SetBinding<ExtendedMap> (Label.TextProperty, vm => vm.SelectedPin.Label);

			var addressLabel = new Label {
				Text = "Address Shows Here",
				TextColor = Color.Gray,
			};

			Device.OnPlatform (iOS: () => addressLabel.Font = Font.SystemFontOfSize (14),
				Android: () => addressLabel.Font = Font.SystemFontOfSize (14),
				WinPhone: () => addressLabel.Font = Font.SystemFontOfSize (18));

			addressLabel.BindingContext = _extendedMap;
			addressLabel.SetBinding<ExtendedMap> (Label.TextProperty, vm => vm.SelectedPin.Address);

			var pinInfoStackLayout = new StackLayout { Padding = new Thickness (0, 5, 0, 0) };

			pinInfoStackLayout.Children.Add (placeNameLabel);
			pinInfoStackLayout.Children.Add (addressLabel);
			pinInfoStackLayout.Spacing = 0;

			footerGrid.Children.Add (pinInfoStackLayout, 0, 0);

		    var footerTopSectionHeight = footerHeight*0.2;
            var navigationImageButtonHeight = footerTopSectionHeight - (0.007 * footerTopSectionHeight);
		    var navigationImageButtonWidth = (0.15 * _pageWidth);

		    var navigationImageButton = CreateImageButton("navigate-icon.svg",navigationImageButtonHeight, navigationImageButtonWidth, (view, o) =>
		    {
		        var selectedPin = _extendedMap.SelectedPin;
		        DependencyService.Get<IPhoneService>().LaunchNavigationAsync(new NavigationModel
		        {
		            Latitude = selectedPin.Position.Latitude,
		            Longitude = selectedPin.Position.Longitude,
		            DestinationAddress = selectedPin.Address,
		            DestinationName = selectedPin.Label
		        });
		    });

            navigationImageButton.Padding = new Thickness(0, (navigationImageButtonHeight / 2.5) * -1, 0, 0);
		    footerGrid.Children.Add (navigationImageButton, 1, 0);

			footerMasterGrid.Children.Add (footerGrid, 1, 0);

			footerMainGrid.Children.Add (CreateFooterDetails (footerHeight), 0, 1);
			footerMainGrid.Children.Add (footerMasterGrid, 0, 0);

			return new ContentView { Content = footerMainGrid, BackgroundColor = Color.White };
		}

		ScrollView CreateFooterDetails (double footerDetailsHeight)
		{
			var footerDetailsGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (0.23, GridUnitType.Star)
					},
					new RowDefinition {
						Height = new GridLength (0.25, GridUnitType.Star)
					},
					new RowDefinition {
						Height = new GridLength (0.3, GridUnitType.Star)
					},
					new RowDefinition {
						Height = new GridLength (0.22, GridUnitType.Star)
					},
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (0.025, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (0.95, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (0.025, GridUnitType.Star)
					},
				},
				RowSpacing = 10,
				Padding = new Thickness (0, 0, 0, 0)
			};

			footerDetailsGrid.Children.Add (CreateActionButtonsGrid (), 1, 0);
			footerDetailsGrid.Children.Add (CreateScheduleGrid (), 1, 1);
			footerDetailsGrid.Children.Add (CreateOtherView (), 1, 2);

			return new ScrollView {
				Content = new ContentView {
					Content = footerDetailsGrid,
					HeightRequest = footerDetailsHeight
				},
			};
		}

		Grid CreateActionButtonsGrid ()
		{
			var actionButtonsGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					}
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (0.2, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (0.25, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (0.1, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (0.25, GridUnitType.Star)
					},
					new ColumnDefinition {
						Width = new GridLength (0.2, GridUnitType.Star)
					},
				},
				BackgroundColor = Color.White
			};

            //var callImageButton = CreateImageButton ("call_icon.png", "Call", (view, o) => {
            //    var phoneNumber = _extendedMap.SelectedPin.PhoneNumber;
            //    DependencyService.Get<IPhoneService> ().DialNumber (phoneNumber);
            //});

            //var shareImageButton = CreateImageButton ("share_icon.png", "Share", (view, o) => {
            //    var selectedPin = _extendedMap.SelectedPin;
            //    var text = string.Format ("I am playing vball at {0}, {1}.", selectedPin.Label, selectedPin.Address);
            //    DependencyService.Get<IPhoneService> ().ShareText (text);
            //});

            //actionButtonsGrid.Children.Add (callImageButton, 1, 0);
            //actionButtonsGrid.Children.Add (shareImageButton, 3, 0);

			return actionButtonsGrid;
		}

		Grid CreateScheduleGrid ()
		{
			var scheduleGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					}
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					},
						

				},
				BackgroundColor = Color.White
			};

			var listview = new ListView { };

			//Don't allow selection
			listview.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				listview.SelectedItem = null;
			};

			var itemTemplate = new DataTemplate (typeof(TextCell));

            itemTemplate.SetBinding(TextCell.TextProperty, "Day");
            itemTemplate.SetValue(TextCell.TextColorProperty, Color.Black);
            itemTemplate.SetBinding(TextCell.DetailProperty, "HoursOfOperation");
            itemTemplate.SetValue(TextCell.DetailColorProperty, Color.Gray);

			listview.ItemTemplate = itemTemplate;
			listview.BindingContext = _extendedMap;
			listview.SetBinding<ExtendedMap> (ListView.ItemsSourceProperty, vm => vm.SelectedPin.ScheduleEntries);

			scheduleGrid.Children.Add (listview, 0, 0);

			return scheduleGrid;
		}

		View CreateOtherView ()
		{
			var contentView = new ContentView { BackgroundColor = Color.White };

			var listview = new ListView { };

			//Don't allow selection
			listview.ItemSelected += (object sender, SelectedItemChangedEventArgs e) => {
				var url = e.SelectedItem as Url;

				if (url != null && url.Value.Contains ("www")) {
					DependencyService.Get<IPhoneService> ().OpenBrowser (url.Value);
				}

				listview.SelectedItem = null;
			};

            var itemTemplate = new DataTemplate(typeof(TextCell));

            itemTemplate.SetBinding(TextCell.TextProperty, "Key");
            itemTemplate.SetValue(TextCell.TextColorProperty, Color.Black);
            itemTemplate.SetBinding(TextCell.DetailProperty, "Value");
            itemTemplate.SetValue(TextCell.DetailColorProperty, Color.Gray);

			listview.ItemTemplate = itemTemplate;
			listview.BindingContext = _extendedMap;
			listview.SetBinding<ExtendedMap> (ListView.ItemsSourceProperty, vm => vm.SelectedPin.Others);


			contentView.Content = listview;

			return contentView;
		}

        ContentView CreateImageButton(string buttonImage, double height, double width, Action<View, Object> tappedCallback)
        {
            var grid = new Grid
            {
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
                RowSpacing = 0
            };

            var navImage = new SvgImage
            {
                SvgPath = string.Format("ExtendedMap.Forms.Plugin.Abstractions.Images.{0}", buttonImage),
                SvgAssembly = typeof(CustomMapContentView).GetTypeInfo().Assembly,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = height,
                WidthRequest = width
            };

            grid.GestureRecognizers.Add(new TapGestureRecognizer(tappedCallback));

            grid.Children.Add(navImage, 0, 0);

            return new ContentView { Content = grid };
        }


		ContentView CreateImageButton (string buttonImage, string buttonText, double height, double width, Action<View, Object> tappedCallback)
		{
			var grid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					},
                    //new RowDefinition {
                    //    Height = new GridLength (0.38, GridUnitType.Star)
                    //},
                    //new RowDefinition {
                    //    Height = new GridLength (0.4, GridUnitType.Star)
                    //},
                    //new RowDefinition {
                    //    Height = new GridLength (0.1, GridUnitType.Star)
                    //},
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					},

				},
				BackgroundColor = Color.Transparent,
				HorizontalOptions = LayoutOptions.Center,
				RowSpacing = 0
			};

			var navImageGrid = new Grid {
				RowDefinitions = new RowDefinitionCollection {
					new RowDefinition {
						Height = new GridLength (1, GridUnitType.Star)
					}
				},
				ColumnDefinitions = new ColumnDefinitionCollection {
                    //new ColumnDefinition {
                    //    Width = new GridLength (0.28, GridUnitType.Star)
                    //},
					new ColumnDefinition {
						Width = new GridLength (1, GridUnitType.Star)
					},
                    //new ColumnDefinition {
                    //    Width = new GridLength (0.28, GridUnitType.Star)
                    //},

				}
			};

			var navImage = new SvgImage {
                SvgPath = string.Format("ExtendedMap.Forms.Plugin.Abstractions.Images.{0}",buttonImage),
                SvgAssembly = typeof(CustomMapContentView).GetTypeInfo().Assembly,
                //Aspect = Aspect.Fill,
                //HorizontalOptions = LayoutOptions.Center,
                HeightRequest = height,
                WidthRequest = width
			};

			grid.GestureRecognizers.Add (new TapGestureRecognizer (tappedCallback));

			navImageGrid.Children.Add (navImage, 0, 0);

			var label = new Label {
				Text = buttonText,
				Font = Font.SystemFontOfSize (16),
				TextColor = Colors.DarkBlue,
				HorizontalOptions = LayoutOptions.Center
			};

			grid.Children.Add (navImageGrid, 0, 0);
            //grid.Children.Add (label, 0, 2);

			return new ContentView { Content = grid };
		}

		#endregion UI Creation
	}

	public enum FooterMode
	{
		Expanded,
		Minimized,
		Hidden
	}
}