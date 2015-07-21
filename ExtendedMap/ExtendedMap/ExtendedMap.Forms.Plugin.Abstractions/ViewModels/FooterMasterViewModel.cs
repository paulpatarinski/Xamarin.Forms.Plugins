using System;
using ExtendedMap.Forms.Plugin.Abstractions.Models;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace ExtendedMap.Forms.Plugin.Abstractions.ViewModels
{
	public class FooterMasterViewModel : INotifyPropertyChanged
	{
		public FooterMasterViewModel (ExtendedMap extendedMap)
		{
			_extendedMap = extendedMap;
			Address = extendedMap.SelectedPin.Address;
			SvgAssembly = typeof(CustomMapContentView).GetTypeInfo ().Assembly;
//
//				var navImage = new SvgImage {
//				SvgPath = string.Format ("ExtendedMap.Forms.Plugin.Abstractions.Images.{0}", buttonImage),
//				SvgAssembly = typeof(CustomMapContentView).GetTypeInfo ().Assembly,
//				HorizontalOptions = LayoutOptions.Center,
//				HeightRequest = height,
//				WidthRequest = width
//			};

		}

		ExtendedMap _extendedMap;

		ExtendedPin _sPin;

		public string Address { get; set;
		}

		public ExtendedPin SPin {
			get{
				if(_sPin == null)
				{
					_sPin = _extendedMap.SelectedPin;
				}

				return _sPin;
			}
			set{
				_sPin = value;
				OnPropertyChanged ("SPin");
			}
		}

		public Assembly SvgAssembly;

		#region INotifyPropertyChanged implementation

		// boiler-plate
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
		protected bool SetField<T>(ref T field, T value, string propertyName)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}
		#endregion

}
}

