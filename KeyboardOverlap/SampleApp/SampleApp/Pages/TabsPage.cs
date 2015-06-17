using System;

using Xamarin.Forms;

namespace SampleApp
{
	public class TabsPage : TabbedPage
	{
		public TabsPage ()
		{
			Title = "Tabs Page";
			Children.Add (new EntriesOnly ());
			Children.Add (new WithOtherContent ());
			Children.Add (new WithScrollView ());
		}
	}
}


