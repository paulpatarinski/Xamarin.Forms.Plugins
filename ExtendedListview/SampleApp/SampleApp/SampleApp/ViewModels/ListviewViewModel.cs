using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExtendedListview.Forms.Plugin.Abstractions;
using SampleApp.Models;
using Xamarin.Forms;

namespace SampleApp.ViewModels
{
  public class ListviewViewModel : INotifyPropertyChanged
  {
    private bool _isLoading;
    private Command<LoadMoreQuery> _loadMoreCommand;
    private ObservableCollection<Person> _people;
    private int _y = 1;

    public Command<LoadMoreQuery> LoadMoreCommand
    {
      get
      {
        return _loadMoreCommand ?? new Command<LoadMoreQuery>(async param =>
        {
          await LoadMoreExecute(param);
        }, CanExecuteLoadMore);
      }
      set { _loadMoreCommand = value; }
    }

    /// <summary>
    /// Used in the LoadMoreCommand CanExecute and the Page.IsBusy
    /// </summary>
    public bool IsLoading
    {
      get { return _isLoading; }
      set
      {
        _isLoading = value;
        OnPropertyChanged();
      }
    }

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

    private bool CanExecuteLoadMore(LoadMoreQuery loadMoreQuery)
    {
      return !IsLoading;
    }

    private async Task LoadMoreExecute(LoadMoreQuery loadMoreQuery)
    {
      IsLoading = true;

      //Simulate Server Call
      await Task.Delay(TimeSpan.FromSeconds(2));

      Debug.WriteLine("Page Number {0}, Page Size {1}", loadMoreQuery.PageNumber, loadMoreQuery.PageSize);

      for (var i = 1; i <= loadMoreQuery.PageSize; i++, _y++)
      {
        People.Add(new Person
        {
          FirstName = "John " + _y,
          LastName = "Doe",
          PhoneNumber = string.Format("(262)564-123{0}", _y),
          Address = string.Format("12{0} Lake ave", _y)
        });
      }

      IsLoading = false;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}