using SampleApp.ViewModel;

namespace SampleApp.Pages
{
  public partial class ExtendedTextCellListview
  {
    public ExtendedTextCellListview()
    {
      InitializeComponent();
      BindingContext = new ListviewViewModel();
    }
  }
}
