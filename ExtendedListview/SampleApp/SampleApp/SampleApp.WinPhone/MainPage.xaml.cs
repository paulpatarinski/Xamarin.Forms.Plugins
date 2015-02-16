using ExtendedListview.Forms.Plugin.WindowsPhone;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

namespace SampleApp.WinPhone
{
  public partial class MainPage : FormsApplicationPage
  {
    // Constructor
    public MainPage()
    {
      InitializeComponent();
      
      Forms.Init();
      ExtendedListviewRenderer.Init();

      LoadApplication(new SampleApp.App());
      // Sample code to localize the ApplicationBar
      //BuildLocalizedApplicationBar();
    }

    // Sample code for building a localized ApplicationBar
    //private void BuildLocalizedApplicationBar()
    //{
    //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
    //    ApplicationBar = new ApplicationBar();

    //    // Create a new button and set the text value to the localized string from AppResources.
    //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
    //    appBarButton.Text = AppResources.AppBarButtonText;
    //    ApplicationBar.Buttons.Add(appBarButton);

    //    // Create a new menu item with the localized string from AppResources.
    //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
    //    ApplicationBar.MenuItems.Add(appBarMenuItem);
    //}
  }
}