using SampleApp.ViewModel;

namespace SampleApp.Pages
{
  public partial class ViaXaml
  {
    public ViaXaml()
    {
      InitializeComponent();
      BindingContext = new ViaXamlViewModel();
    }
  }
}
