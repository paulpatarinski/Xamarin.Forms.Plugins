using SampleApp.ViewModel;

namespace SampleApp.Pages
{
  public partial class TwoColumnCellListview
  {
    public TwoColumnCellListview()
    {
      InitializeComponent();
      BindingContext = new ListviewViewModel();
    }
  }
}
