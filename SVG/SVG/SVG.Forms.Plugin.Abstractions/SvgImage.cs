using System.Reflection;
using Xamarin.Forms;

namespace SVG.Forms.Plugin.Abstractions
{
    public class SvgImage : Image
    {
        private string _svgPath;
        private Assembly _svgAssembly;

        /// <summary>
        /// The path to the svg file
        /// </summary>
        public string SvgPath
        {
            get { return _svgPath; }
            set { _svgPath = value; }
        }

        /// <summary>
        /// The assembly containing the svg file
        /// </summary>
        public Assembly SvgAssembly
        {
            get { return _svgAssembly; }
            set { _svgAssembly = value; }
        }
    }
}