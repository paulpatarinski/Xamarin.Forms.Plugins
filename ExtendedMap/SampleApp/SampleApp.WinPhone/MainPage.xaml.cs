using ExtendedCells.Forms.Plugin.WindowsPhone;
using ExtendedMap.Forms.Plugin.WindowsPhone;
using Microsoft.Phone.Controls;
using SVG.Forms.Plugin.WindowsPhone;
using Xamarin;

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
            SvgImageRenderer.Init();
            TwoColumnCellRenderer.Init();
            ExtendedMapRenderer.Init();

            LoadApplication(new SampleApp.App());
        }
    }
}
