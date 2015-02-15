using System.Collections.Generic;
using SampleApp.Pages;
using Xamarin.Forms;
using MenuItem = SampleApp.Models.MenuItem;

namespace SampleApp
{
  public class App : Application
  {
    public App()
    {
      var listviewTabbedPage = new TabbedPage();

      listviewTabbedPage.Children.Add(new TwoColumnCellListview());
      listviewTabbedPage.Children.Add(new StackLayoutCell());

      var masterDetailPage = new MasterDetailPage();

      var menuItemListview = new ListView
      {
        ItemsSource = new List<string> {MenuItem.Listview, MenuItem.TableLayout}
      };

      menuItemListview.ItemSelected += (sender, args) =>
      {
        switch (args.SelectedItem.ToString())
        {
          case MenuItem.Listview:
          {
            masterDetailPage.Detail = listviewTabbedPage;
            masterDetailPage.IsPresented = false;
            return;
          }
          case MenuItem.TableLayout:
          {
            masterDetailPage.Detail = new TwoColumnCellTableLayout();
            masterDetailPage.IsPresented = false;
            return;
          }

          default:
          {
            masterDetailPage.Detail = listviewTabbedPage;
            masterDetailPage.IsPresented = false;
            return;
          }
        }
      };

      masterDetailPage.Master = new ContentPage {Content = menuItemListview, Title = "Menu"};
      masterDetailPage.Detail =listviewTabbedPage;


      MainPage = masterDetailPage;
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
