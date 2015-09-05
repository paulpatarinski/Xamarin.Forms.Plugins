using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExtendedMap.Forms.Plugin.Abstractions;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
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

            for (var i = 1; i <= 9; i++)
            {
                SamplePins.Add(new ExtendedPin
                {
                    Address = string.Format("Sample Address {0}",i),
                    Label = string.Format("Test Label {0}",i),
                    PhoneNumber = string.Format("(773)233-123{0}",i),
                    Position = new Position(latitude + (0.01 * i), longitude + (0.01 * i)),
                    Website = "https://www.google.com",
                    ScheduleEntries = new List<ScheduleEntry>
                    {
                        new ScheduleEntry { Day = "Monday", HoursOfOperation = "8 am - 5 pm" },
                        new ScheduleEntry { Day = "Tuesday", HoursOfOperation = "8 am - 5 pm" },
                        new ScheduleEntry { Day = "Wednesday", HoursOfOperation = "8 am - 5 pm" },
                        new ScheduleEntry { Day = "Thusday", HoursOfOperation = "8 am - 5 pm" },
                        new ScheduleEntry { Day = "Friday", HoursOfOperation = "8 am - 5 pm" },
                    }
                });
            }
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