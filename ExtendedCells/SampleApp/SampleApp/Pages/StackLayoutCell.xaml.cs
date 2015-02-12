using SampleApp.ViewModel;

namespace SampleApp.Pages
{
  public partial class StackLayoutCell
  {
    public StackLayoutCell()
    {
      InitializeComponent();
      BindingContext = new ListviewViewModel();
    }
  }
}
