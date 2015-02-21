using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SampleApp.ViewModel;

namespace SampleApp
{
	public partial class ViaResources : ContentPage
	{
		public ViaResources ()
		{
			InitializeComponent ();
			BindingContext = new ViaXamlViewModel ();
		}
	}
}

