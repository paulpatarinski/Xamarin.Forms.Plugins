using SampleApp.Pages;

namespace SampleApp
{
    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            MainPage = new RoundedBoxViewPage();
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
