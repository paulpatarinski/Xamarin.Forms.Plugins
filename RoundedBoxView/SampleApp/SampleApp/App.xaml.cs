using SampleApp.Pages;

namespace SampleApp
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

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
