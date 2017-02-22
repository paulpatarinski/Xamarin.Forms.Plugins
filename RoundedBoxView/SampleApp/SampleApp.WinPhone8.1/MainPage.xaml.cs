namespace SampleApp.WinPhone8._1
{
    using Windows.UI.Xaml.Navigation;
    using RoundedBoxView.Forms.Plugin.WindowsPhone8._1;

    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadApplication(new SampleApp.App());
            NavigationCacheMode = NavigationCacheMode.Required;
        }
    }
}
