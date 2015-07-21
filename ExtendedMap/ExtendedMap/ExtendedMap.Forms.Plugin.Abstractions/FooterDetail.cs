using System;
using Xamarin.Forms;
using ExtendedMap.Forms.Plugin.Abstractions.Services;
using ExtendedCells.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.Abstractions.Models;

namespace ExtendedMap.Forms.Plugin.Abstractions
{
	public class FooterDetail : ContentView
	{
		public FooterDetail (UIHelper uiHelper, ExtendedMap extendedMap, Footer footer)
		{
			_uiHelper = uiHelper;
			_extendedMap = extendedMap;
			_footer = footer;

			Content = CreateFooterDetails ();
		}

		UIHelper _uiHelper;

		ExtendedMap _extendedMap;

		Footer _footer;

		private ScrollView CreateFooterDetails ()
		{
			var relativeLayout = new RelativeLayout ();

			//todo : change height from 200 to relative
			relativeLayout.Children.Add (CreateActionButtonsGrid (200),
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
					return (parent.Height * 0.12);
				})
			);

			relativeLayout.Children.Add (CreateScheduleGrid (),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0.12);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 1);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0.2);
				})
			);

			relativeLayout.Children.Add (CreateOtherView (),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0.05);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0.35);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 1);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0.15);
				})
			);

			//Make the Details section Toggle the footer when tapped
			relativeLayout.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (_footer.ToogleFooter)
			});

			return new ScrollView {
				Content = relativeLayout, BackgroundColor = Color.White
			};
		}


		private RelativeLayout CreateActionButtonsGrid (double footerTopSectionHeight)
		{
			var relativeLayout = new RelativeLayout {BackgroundColor = Color.White};

			var callImageButton = _uiHelper.CreateImageButton ("phone-icon.svg", "CALL", (footerTopSectionHeight / 2),
				(footerTopSectionHeight / 2), (view, o) => {
					var phoneNumber = _extendedMap.SelectedPin.PhoneNumber;
					var name = _extendedMap.SelectedPin.Label;
					DependencyService.Get<IPhoneService> ().DialNumber (phoneNumber, name);
				});


			var shareImageButton = _uiHelper.CreateImageButton ("share-icon.svg", "SHARE", (footerTopSectionHeight / 2),
				(footerTopSectionHeight / 2), (view, o) => {
					var selectedPin = _extendedMap.SelectedPin;
					var shareText =
						string.IsNullOrEmpty(_extendedMap.ShareText)
						? string.Format("Let's meet at {0},{1}",
							selectedPin.Label, selectedPin.Address)
						: _extendedMap.ShareText;
					DependencyService.Get<IPhoneService> ().ShareText (shareText);
				});

			var websiteButton = _uiHelper.CreateImageButton ("browser-icon.svg", "WEBSITE", (footerTopSectionHeight / 2),
				(footerTopSectionHeight / 2), (view, o) => {
					var websiteUrl = _extendedMap.SelectedPin.Website;

					DependencyService.Get<IPhoneService> ().OpenBrowser (websiteUrl);
				});



			relativeLayout.Children.Add (callImageButton,
				Constraint.RelativeToParent ((parent) => (parent.Width * 0.08)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0.2)),
				Constraint.RelativeToParent ((parent) => (parent.Width * 0.2)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0.65))
			);

			relativeLayout.Children.Add (shareImageButton,
				Constraint.RelativeToParent ((parent) => (parent.Width * 0.4)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0.2)),
				Constraint.RelativeToParent ((parent) => (parent.Width * 0.2)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0.65))
			);


			relativeLayout.Children.Add (websiteButton,
				Constraint.RelativeToParent ((parent) => (parent.Width * 0.73)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0.2)),
				Constraint.RelativeToParent ((parent) => (parent.Width * 0.2)),
				Constraint.RelativeToParent ((parent) => (parent.Height * 0.65))
			);

			return relativeLayout;
		}

		private Grid CreateScheduleGrid ()
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

			var listview = new ListView {SeparatorVisibility = SeparatorVisibility.None};

			//Don't allow selection
			listview.ItemSelected += (sender, e) => {
				listview.SelectedItem = null;
			};

			var itemTemplate = new DataTemplate (typeof(ExtendedTextCell));

		    var cellPadding = new Thickness(40, 0, 0, 0);

            Device.OnPlatform(WinPhone:() =>
		    {
		        cellPadding = new Thickness(25,0,0,0);
		    });

			itemTemplate.SetValue (ExtendedTextCell.ThicknessProperty, cellPadding);
			itemTemplate.SetValue (ExtendedTextCell.LeftColumnWidthProperty, new GridLength (1.0, GridUnitType.Star));
			itemTemplate.SetBinding (ExtendedTextCell.LeftTextProperty, "Day");
			itemTemplate.SetValue (ExtendedTextCell.LeftTextColorProperty, Color.Black);
			itemTemplate.SetBinding (ExtendedTextCell.LeftDetailProperty, "HoursOfOperation");
			itemTemplate.SetValue (ExtendedTextCell.LeftDetailColorProperty, Color.Gray);

			listview.ItemTemplate = itemTemplate;
			listview.BindingContext = _extendedMap;
			listview.SetBinding<ExtendedMap> (ListView.ItemsSourceProperty, vm => vm.SelectedPin.ScheduleEntries);

			scheduleGrid.Children.Add (listview, 0, 0);

			return scheduleGrid;
		}

		private View CreateOtherView ()
		{
			var contentView = new ContentView { BackgroundColor = Color.White };

			var listview = new ListView {SeparatorVisibility = SeparatorVisibility.None};

			//Don't allow selection
			listview.ItemSelected += (sender, e) => {
				listview.SelectedItem = null;
			};

			var itemTemplate = new DataTemplate (typeof(ExtendedTextCell));

			itemTemplate.SetValue (ExtendedTextCell.LeftColumnWidthProperty, new GridLength (0.85, GridUnitType.Star));
			itemTemplate.SetValue (ExtendedTextCell.RightColumnWidthProperty, new GridLength (0.15, GridUnitType.Star));
			itemTemplate.SetBinding (ExtendedTextCell.LeftTextProperty, "Key");
			itemTemplate.SetValue (ExtendedTextCell.LeftTextColorProperty, Color.Black);
			itemTemplate.SetBinding (ExtendedTextCell.LeftDetailProperty, "Value");
			itemTemplate.SetValue (ExtendedTextCell.LeftDetailColorProperty, Color.Gray);

			listview.ItemTemplate = itemTemplate;
			listview.BindingContext = _extendedMap;
			listview.SetBinding<ExtendedMap> (ListView.ItemsSourceProperty, vm => vm.SelectedPin.Others);


			contentView.Content = listview;

			return contentView;
		}
	}
}

