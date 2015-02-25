using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.Android;

namespace UiTests
{
	public static class IAppExtensions
	{
		public static void Tap(this IApp app, string styleId)
		{
			app.Tap(c => c.Marked(styleId));
		}

		public static DeviceType DeviceType(this IApp app)
		{
			if (app is AndroidApp)
				return UiTests.DeviceType.Android;

			return UiTests.DeviceType.iOS;
		}

		public static AppResult[] FindAllImages(this IApp app)
		{
			return app.DeviceType() == UiTests.DeviceType.Android ? app.Query (c => c.Class ("ImageView")) : app.Query (c => c.Class ("UiImage"));

		}
	}

	public enum DeviceType
	{
		iOS,
		Android
	}
}

