using Xamarin.Forms;
using ExtendedMap.Forms.Plugin.Android;

[assembly: ExportRenderer(typeof(ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof(ExtendedMapRenderer))]
namespace ExtendedMap.Forms.Plugin.Android
{
    /// <summary>
    /// ExtendedMap Renderer
    /// </summary>
    public class ExtendedMapRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }
    }
}