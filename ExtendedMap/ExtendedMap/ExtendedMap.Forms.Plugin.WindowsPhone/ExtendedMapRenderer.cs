using Xamarin.Forms;
using ExtendedMap.Forms.Plugin.WindowsPhone;

[assembly: ExportRenderer(typeof(ExtendedMap.Forms.Plugin.Abstractions.ExtendedMap), typeof(ExtendedMapRenderer))]
namespace ExtendedMap.Forms.Plugin.WindowsPhone
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
