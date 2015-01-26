using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExtendedMap.Forms.Plugin.Abstractions;
using SampleApp.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SampleApp.ViewModels
{
    public class ExtendedMapViewModel : INotifyPropertyChanged
    {
      public ExtendedMapViewModel()
      {
        Device.BeginInvokeOnMainThread(() =>
        {
          SamplePins.Add(new ExtendedPin
          {
            Address = "8832 West Dempster Street, Niles, IL 60714",
            Label = "Portillo's",
            Position = new Position(42.0412592, -87.8534305),
            PinIcon = Icons.FoodBowl,
            PhoneNumber = "(847)795-0600"
          });


          SamplePins.Add(new ExtendedPin
          {
            Address = "8265 West Golf Road, Niles, IL 60714",
            Label = "Himalayan Restaurant",
            Position = new Position(42.0399843, -87.8444183),
            PinIcon = Icons.Chicken,
            PhoneNumber = "(847)324-4150"
          });
        });
      }

      private ObservableCollection<ExtendedPin> _samplePins;

        public ObservableCollection<ExtendedPin> SamplePins
        {
            get
            {
                if (_samplePins == null)
                {
                    _samplePins = new ObservableCollection<ExtendedPin>();
                }

                return _samplePins;
            }
            set
            {
                _samplePins = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}