using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp.ViewModel
{
  public class ListviewViewModel : INotifyPropertyChanged
  {
    public ListviewViewModel()
    {
      for (var i = 1; i <= 100; i++)
      {
        People.Add(new Person
        {
          FirstName = "John " + i,
          LastName = "Doe",
          PhoneNumber = string.Format("(262)564-123{0}", i),
          Address = string.Format("12{0} Lake ave", i)
        });
      }
    }

    private ObservableCollection<Person> _people;

    public ObservableCollection<Person> People
    {
      get
      {
        if (_people == null)
        {
          _people = new ObservableCollection<Person>();
        }

        return _people;
      }
      set
      {
        _people = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
