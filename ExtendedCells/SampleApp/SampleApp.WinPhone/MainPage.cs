using ExtendedCells.Forms.Plugin.WindowsPhone;
using Microsoft.Phone.Controls;
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
