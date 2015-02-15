using SampleApp.ViewModel;
using Xamarin.Forms;

namespace PluginSampleApp.Pages
{
    public partial class TwoColumnCellListview : ContentPage
    {
        public TwoColumnCellListview()
        {
            InitializeComponent();
            BindingContext = new ListviewViewModel();
        }
    }
}
