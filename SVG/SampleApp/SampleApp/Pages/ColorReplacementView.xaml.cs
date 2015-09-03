using SampleApp.ViewModel;

namespace SampleApp.Pages
{
  public partial class ColorReplacementView
  {
      public ColorReplacementView( )
    {
      InitializeComponent();
      BindingContext = new ViaXamlViewModel();
    }
  }
}