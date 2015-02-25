using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Linq;
using UiTests;
using FluentAssertions;

namespace UsingUITest.UITests
{
	public class CrossPlatformTests
	{
		protected IApp app;

		/// <summary>
		/// We do 'Ignore' in the base class so that these set of tests aren't actually *run*
		/// outside the context of one of the platform-specific bootstrapper sub-classes.
		/// </summary>
		[SetUp]
		public virtual void SetUp()
		{
			Assert.Ignore ("This class requires a platform-specific bootstrapper to override the `SetUp` method");
		}

		[Test ()]
		public void Svg_ShouldBeGreatedThen_2Images ()
		{
			app.Tap("SVG");

			app.WaitFor (() => {
				var images = app.FindAllImages ();

				return images.Count() > 2;
			}, "Not able to find all images", TimeSpan.FromSeconds(10));
		}

		[Test ()]
		public void ExtendedMap_ShouldOpen ()
		{
			app.Tap("Extended Map");

			app.WaitFor (TimeSpan.FromSeconds (20));

			app.DoubleTapCoordinates (300, 300);

			app.Screenshot ("Map screenshot");
		}

		[Test ()]
		public void ExtendedListview_ShouldOpen ()
		{
			app.Tap("Extended Cell Listview");

			app.WaitFor (TimeSpan.FromSeconds (20));

			app.ScrollDown ();
			app.ScrollDown ();
			app.ScrollUp ();
		}

		[Test ()]
		public void ExtendedTableView_ShouldOpen ()
		{
			app.Tap("Extended Cell TableView");

			app.WaitFor (TimeSpan.FromSeconds (20));

			app.ScrollDown ();
			app.ScrollDown ();
		}
	}
}
