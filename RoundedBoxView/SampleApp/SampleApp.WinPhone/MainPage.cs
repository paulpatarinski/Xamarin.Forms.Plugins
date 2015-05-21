using Microsoft.Phone.Controls;
using RoundedBoxView.Forms.Plugin.WindowsPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace SampleApp.WinPhone
{
    public partial class MainPage : FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;

            Forms.Init();
            RoundedBoxViewRenderer.Init();

            LoadApplication(new SampleApp.App());
        }
    }
}
