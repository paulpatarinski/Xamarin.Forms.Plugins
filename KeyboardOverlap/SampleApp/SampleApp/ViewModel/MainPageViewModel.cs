using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleApp
{
	public class MainPageViewModel
	{
		private List<string> _pages;

		public List<string> Pages {
			get {
				if (_pages == null) {
					_pages = new List<string> { PageTitle.EntriesOnlyPage,
						PageTitle.TabbedPage,
						PageTitle.WithOtherContent,
						PageTitle.WithScrollView
					};

				}

				return _pages;
			}
			set { _pages = value; }
		}
	}
}

