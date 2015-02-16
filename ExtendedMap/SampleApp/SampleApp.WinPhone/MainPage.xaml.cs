using Microsoft.Phone.Controls;
using Xamarin;
using Forms.Plugin.WindowsPhone;

namespace SampleApp.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Xamarin.Forms.Forms.Init();
            FormsMaps.Init();
            ExtendedMapRenderer.Init();

            LoadApplication(new SampleApp.App());
        }
    }
}
