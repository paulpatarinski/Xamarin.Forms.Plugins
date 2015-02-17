using SampleApp.ViewModels;
using Xamarin.Forms;

namespace SampleApp.Pages
{
  public partial class IncrementalListview : ContentPage
  {
    public IncrementalListview()
    {
      InitializeComponent();
      BindingContext = new ListviewViewModel();
    }
  }
}