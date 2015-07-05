using System;
using Xamarin.Forms;
using ExtendedMap.Forms.Plugin.Abstractions.Services;
using ExtendedMap.Forms.Plugin.Abstractions.Models;

namespace ExtendedMap.Forms.Plugin.Abstractions
{
	public class FooterMaster : ContentView
	{
		public FooterMaster (ExtendedMap extendedMap, UIHelper uiHelper, Footer footer)
		{
			_extendedMap = extendedMap;
			_uiHelper = uiHelper;
			_footer = footer;

			Content = CreateFooter ();
		}

		ExtendedMap _extendedMap;
		UIHelper _uiHelper;
		Footer _footer;

		private ContentView CreateFooter ()
		{
			var footerMasterLayout = new RelativeLayout ();

			var placeNameLabel = new Label {
				Text = "Pin Label Shows Here",
				TextColor = Color.Black,
			};

			Device.OnPlatform (iOS: () => placeNameLabel.FontSize = 20,
				Android: () => placeNameLabel.FontSize = 20,
				WinPhone: () => placeNameLabel.FontSize = 24);

			placeNameLabel.BindingContext = _extendedMap;

			placeNameLabel.SetBinding<ExtendedMap> (Label.TextProperty, vm => vm.SelectedPin.Label);

			var addressLabel = new Label {
				Text = "Address Shows Here",
				TextColor = Color.Gray,
			};

			Device.OnPlatform (iOS: () => addressLabel.FontSize = 14,
				Android: () => addressLabel.FontSize = 14,
				WinPhone: () => addressLabel.FontSize = 18);

			addressLabel.BindingContext = _extendedMap;
			addressLabel.SetBinding<ExtendedMap> (Label.TextProperty, vm => vm.SelectedPin.Address);

			footerMasterLayout.Children.Add (
				placeNameLabel,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0.05);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0.12);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0.9);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 1);
				})
			);

			footerMasterLayout.Children.Add (
				addressLabel,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0.05);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0.52);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0.9);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 1);
				})
			);

			var tappableRegion = new StackLayout { BackgroundColor = Color.Transparent };

			tappableRegion.GestureRecognizers.Add (new TapGestureRecognizer {
				Command = new Command (_footer.ToogleFooter)
			});

			footerMasterLayout.Children.Add (
				tappableRegion,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0.85);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 1);
				})
			);


			var navigationImageButton = _uiHelper.CreateImageButton ("navigate-icon.svg", (200),
				(200), () => {
					var selectedPin = _extendedMap.SelectedPin;
					DependencyService.Get<IPhoneService> ().LaunchNavigationAsync (new NavigationModel {
						Latitude = selectedPin.Position.Latitude,
						Longitude = selectedPin.Position.Longitude,
						DestinationAddress = selectedPin.Address,
						DestinationName = selectedPin.Label
					});
				});


			footerMasterLayout.Children.Add (
				navigationImageButton,
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0.8);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * -0.4);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * 0.16);
				}),
				Constraint.RelativeToParent ((parent) => {
					return (parent.Height * 0.7);
				})
			);


			var footerHeight = 0.23;

			Device.OnPlatform (iOS: () => footerHeight = 0.16,
				Android: () => footerHeight = 0.16,
				WinPhone: () => footerHeight = 0.23);

			var footerLayout = new RelativeLayout ();

			footerLayout.Children.Add (
				footerMasterLayout,
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

			return new ContentView { Content = footerLayout, BackgroundColor = Color.White };
		}

	}
}

