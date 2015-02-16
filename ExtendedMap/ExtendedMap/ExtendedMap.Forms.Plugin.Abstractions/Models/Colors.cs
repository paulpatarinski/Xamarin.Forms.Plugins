using Xamarin.Forms;

namespace ExtendedMap.Forms.Plugin.Abstractions.Models
{
	public struct Colors
	{
		public static Color LightGray = Color.FromHex ("#FFE4E4E2");
		public static Color Gray = Color.FromHex ("#999");
		public static Color LightBlue = Color.FromHex ("#3498DB");
		public static Color DarkRed = Color.FromHex ("#cd0814");

		public static Color DarkBlue { get { return Color.FromHex ("#FF4285F4"); } }
	}
}
