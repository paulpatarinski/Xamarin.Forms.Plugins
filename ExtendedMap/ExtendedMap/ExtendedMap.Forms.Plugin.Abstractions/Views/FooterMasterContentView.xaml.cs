using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ExtendedMap.Forms.Plugin.Abstractions.Services;
using ExtendedMap.Forms.Plugin.Abstractions.ViewModels;

namespace ExtendedMap.Forms.Plugin.Abstractions.Views
{
	public partial class FooterMasterContentView : ContentView
	{
		public FooterMasterContentView(ExtendedMap extendedMap, UIHelper uiHelper, Footer footer)
		{
			_extendedMap = extendedMap;
			_uiHelper = uiHelper;
			_footer = footer;

						BindingContext = new FooterMasterViewModel(extendedMap) ;
//			BindingContext = extendedMap ;
//			Content = CreateFooter ();
			InitializeComponent ();
		}

		ExtendedMap _extendedMap;
		UIHelper _uiHelper;
		Footer _footer;


	}
}

