using System.Collections.Generic;
using Xamarin.Forms;

namespace PluginSampleApp
{
    public class App : Application
    {
        public App()
        {
            var listview = new ListView();

            var navigationPage = new NavigationPage(new ContentPage
            {
                Content = listview
            });

            listview.ItemsSource = new List<string>
            {
                PageTitle.SVG,
                PageTitle.ExtendedMap
            };

            listview.ItemSelected += (sender, args) =>
            {
                if (args.SelectedItem == null)
                    return;

                switch (args.SelectedItem.ToString())
                {
                    case PageTitle.SVG:
                    {
                        navigationPage.Navigation.PushAsync(new SVGPage());
                        break;
                    }
                    case PageTitle.ExtendedMap:
                    {
                        navigationPage.Navigation.PushAsync(new ExtendedMapPage());
                        break;
                    }
                }

                listview.SelectedItem = null;
            };

            // The root page of your application
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}