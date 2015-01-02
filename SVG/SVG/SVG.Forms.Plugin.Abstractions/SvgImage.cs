using System.Reflection;
using Xamarin.Forms;

namespace SVG.Forms.Plugin.Abstractions
{
    public class SvgImage : Image
    {
        public static readonly BindableProperty SvgPathProperty =
            BindableProperty.Create<SvgImage, string>(
                p => p.SvgPath, default(string));

        /// <summary>
        /// The path to the svg file
        /// </summary>
        public string SvgPath
        {
            get { return (string) GetValue(SvgPathProperty); }
            set { SetValue(SvgPathProperty, value); }
        }

        public static readonly BindableProperty SvgAssemblyProperty =
          BindableProperty.Create<SvgImage, Assembly>(
              p => p.SvgAssembly, null);

        /// <summary>
        /// The assembly containing the svg file
        /// </summary>
        public Assembly SvgAssembly
        {
            get { return (Assembly)GetValue(SvgAssemblyProperty); }
            set { SetValue(SvgAssemblyProperty, value); }
        }
    }
}