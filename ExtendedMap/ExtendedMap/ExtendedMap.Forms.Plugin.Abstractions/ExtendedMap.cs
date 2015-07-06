using System;
using System.Collections.ObjectModel;
using System.Linq;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ExtendedMap.Forms.Plugin.Abstractions
{
	public class ExtendedMap : Map
	{
		public ExtendedMap (MapSpan mapSpan) : base (mapSpan)
		{

		}

    public static readonly BindableProperty CenterOnPositionProperty = BindableProperty.Create("CenterOnPosition", typeof(Position), typeof(ExtendedMap),default(Position));

		public Position CenterOnPosition {
      get
      {
        return (Position)GetValue(CenterOnPositionProperty);
      }
      set
      {
				        SetValue(CenterOnPositionProperty, value);
				OnPropertyChanged ("CenterOnPosition");	
      }
		}

		public static readonly BindableProperty SelectedPinProperty = BindableProperty.Create<ExtendedMap, ExtendedPin> (x => x.SelectedPin, new ExtendedPin ());

		public ExtendedPin SelectedPin {
			get { return (ExtendedPin)base.GetValue (SelectedPinProperty); }
		}

		public static readonly BindableProperty CustomPinsProperty = BindableProperty.Create<ExtendedMap, ObservableCollection<ExtendedPin>> (x => x.CustomPins, new ObservableCollection<ExtendedPin> (){ new ExtendedPin (){ Label = "test123" } });

		public ObservableCollection<ExtendedPin> CustomPins {
			get{ return (ObservableCollection<ExtendedPin>)base.GetValue (CustomPinsProperty); }
			set{ base.SetValue (CustomPinsProperty, value); }
		}


    string _selectedPinAddress;

    public string SelectedPinAddress
    {
      get { return _selectedPinAddress; }
      set
      {
        _selectedPinAddress = value;

        var selectedPin = CustomPins.FirstOrDefault(x => x.Address.Equals(value)) as ExtendedPin;

        var parent = this.Parent.Parent as CustomMapContentView;

        if (parent == null)
          throw new Exception("Not able to retrieve the parent of the ExtendedMap");

        //Set the Expanded to Expanded (otherwise for some reason the footer minimizes)
        if (parent.Footer.FooterMode == FooterMode.Expanded)
        {
					parent.Footer.FooterMode = FooterMode.Expanded;
        }

        CenterOnPosition = selectedPin.Position;

        base.SetValue(SelectedPinProperty, selectedPin);
      }
    }

	  public static readonly BindableProperty ShareTextProperty =
	    BindableProperty.Create("ShareText", typeof (string), typeof (ExtendedMap), default(string));

	  public string ShareText
	  {
	    get { return (string) GetValue(ShareTextProperty); }
	    set { SetValue(ShareTextProperty, value); }
	  }
	}
}