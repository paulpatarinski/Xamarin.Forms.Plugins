using SampleApp.Pages;
using Xamarin.Forms;

namespace SampleApp
{
    public class App : Application
    {
        public App()
        {
          var tabbedPage = new TabbedPage();

          tabbedPage.Children.Add(new ViaCode());
          tabbedPage.Children.Add(new ViaXaml());

          MainPage = tabbedPage;
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
