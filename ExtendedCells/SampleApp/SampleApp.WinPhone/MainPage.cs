using Microsoft.Phone.Controls;
using SVG.Forms.Plugin.WindowsPhone;
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
            TwoColumnCellRenderer.Init();

            LoadApplication(new SampleApp.App());
        }
    }
}
