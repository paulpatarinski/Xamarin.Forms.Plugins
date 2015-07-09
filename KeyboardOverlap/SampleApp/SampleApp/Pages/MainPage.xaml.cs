using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SampleApp.Pages;

namespace SampleApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
			BindingContext = new MainPageViewModel ();
		}

		private async void OnItemSelected (object sender, SelectedItemChangedEventArgs args)
		{
			var selectedItem = args.SelectedItem.ToString ();

			switch (selectedItem) {

			case PageTitle.EntriesOnlyPage:
				{
					await Navigation.PushAsync (new EntriesOnly ());
					break;
				}

			case PageTitle.TabbedPage:
				{
					await Navigation.PushAsync (new TabsPage ());
					break;
				}
			case PageTitle.WithOtherContent:
				{
					await Navigation.PushAsync (new WithOtherContent ());
					break;
				}
			case PageTitle.WithScrollView:
				{
					await Navigation.PushAsync (new WithScrollView ());
					break;
				}
			case PageTitle.SearchBar:
				{
					await Navigation.PushAsync (new SearchBarPage ());
					break;
				}
			}
		}
	}
}

