using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.ViewModel
{
  public class ListviewViewModel : INotifyPropertyChanged
  {
    public ListviewViewModel()
    {
      SampleList = new ObservableCollection<SampleListviewModel>(new List<SampleListviewModel>());

      LoadSampleDataAsync();
    }

    private ObservableCollection<SampleListviewModel> _sampleList;

    public ObservableCollection<SampleListviewModel> SampleList
    {
      get { return _sampleList; }
      set { _sampleList = value;
      OnPropertyChanged("SampleList");
      }
    }

    private async Task LoadSampleDataAsync()
    {
      for (int i = 0; i < 10; i++)
      {
        SampleList.Add(new SampleListviewModel());
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    // Create the OnPropertyChanged method to raise the event
    protected void OnPropertyChanged(string name)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(name));
      }
    }
  }
}