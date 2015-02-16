using SampleApp.ViewModel;
using Xamarin.Forms;

namespace SampleApp.Pages
{
  public partial class PullToRefreshListview : ContentPage
  {
    public PullToRefreshListview()
    {
      InitializeComponent();
      BindingContext = new ListviewViewModel();
    }
  }
}