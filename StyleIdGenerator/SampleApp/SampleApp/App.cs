using Xamarin.Forms;

namespace SampleApp
{
    public class App : Application
    {
        public App()
        {
            var tabbedPage = new TabbedPage();

            tabbedPage.Children.Add(new Page1());
            tabbedPage.Children.Add(new Page2());

            // The root page of your application
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