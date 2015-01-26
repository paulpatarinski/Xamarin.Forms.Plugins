using Android.App;
using Android.Content;

namespace ExtendedMap.Forms.Plugin.Droid.Extensions
{
  public static class ObjectExtensions
  {
    /// <summary>
    /// Starts the activity using either the object itself if it a type of <see cref="Context"/>
    /// or alternatively using <see cref="Application.Context"/>
    /// </summary>
    /// <param name="o">O.</param>
    /// <param name="intent">Intent.</param>
    public static void StartActivity(this object o, Intent intent)
    {
      var context = o as Context;
      if (context != null)
      {
        context.StartActivity(intent);
      }
      else
      {
        intent.SetFlags(ActivityFlags.NewTask);
        Application.Context.StartActivity(intent);
      }
    }

    public static void StartActivityForResult(this object o, Intent intent)
    {
      var context = o as Context;
      if (context != null)
      {
        context.StartActivityForResult(intent);
      }
      else
      {
        intent.SetFlags(ActivityFlags.NewTask);
        Application.Context.StartActivityForResult(intent);
      }
    }
  }
}
