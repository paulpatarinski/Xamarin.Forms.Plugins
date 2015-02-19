using Xamarin.Forms;

namespace SampleApp.Models
{
  public static class Colors
  {
    public static Color DefaultColor
    {
      get
      {
        var color = Color.White;

        Device.OnPlatform(() =>
        {
          color = Color.Black;
        });

        return color;
      }
    }
  }
}
