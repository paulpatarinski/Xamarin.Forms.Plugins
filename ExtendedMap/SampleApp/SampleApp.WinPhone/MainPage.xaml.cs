using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SVG.Forms.Plugin.WindowsPhone;
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
            SvgImageRenderer.Init();
            ExtendedMapRenderer.Init();

            LoadApplication(new SampleApp.App());
        }
    }
}
