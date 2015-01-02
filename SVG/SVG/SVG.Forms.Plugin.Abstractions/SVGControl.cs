using Xamarin.Forms;

namespace SVG.Forms.Plugin.Abstractions
{
    public class SvgControl : Image
    {
        public static readonly BindableProperty SvgPathProperty =
            BindableProperty.Create<SvgControl, string>(
                p => p.SvgPath, default(string));

        /// <summary>
        /// The path to the svg file
        /// </summary>
        public string SvgPath
        {
            get { return (string) GetValue(SvgPathProperty); }
            set { SetValue(SvgPathProperty, value); }
        }
    }
}