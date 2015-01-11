using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ExtendedMap.Forms.Plugin.Abstractions;
using PluginSampleApp.Annotations;
using Xamarin.Forms.Maps;

namespace PluginSampleApp.ViewModels
{
    public class ExtendedViewModel : INotifyPropertyChanged
    {
        public ExtendedViewModel()
        {
            const double latitude = 41.788081;
            const double longitude = -87.831573;

            Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith((result) =>
            {
                    SamplePins.Add(new ExtendedPin
                    {
                        Address = "Sample Address 1",
                        Label = "Test Label",
                        Position = new Position(latitude, longitude)
                    });


                    SamplePins.Add(new ExtendedPin
                    {
                        Address = "Sample Address 2",
                        Label = "Test Label 2",
                        Position = new Position(latitude + 0.1, longitude)
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}