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

			var images = app.FindAllImages ();

			images.Count ().Should ().BeGreaterThan (2);
		}

		[Test ()]
		public void ExtendedMap_ShouldOpen ()
		{
			app.Tap("Extended Map");

		}
	}
}
