using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.ViewModel;
using Xamarin.Forms;

namespace PluginSampleApp.Pages
{
    public partial class ExtendedTextCellListview : ContentPage
    {
        public ExtendedTextCellListview()
        {
            InitializeComponent();
            BindingContext = new ListviewViewModel();
        }
    }
}
