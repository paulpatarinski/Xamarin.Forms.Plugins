using SampleApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp.Pages
{
  public partial class Listview : ContentPage
  {
    public Listview()
    {
      InitializeComponent();
      BindingContext = new ListviewViewModel();
    }
  }
}
