using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace SVG.Forms.Plugin.Abstractions
{
    public class ColorPairs : ObservableCollection<ColorPair>
    {

    }

    public class ColorPair
    {
        public Color OldColor { get; set; }
        public Color NewColor { get; set; }

        public ColorPair( Color in_OldColor, Color in_NewColor ) : this( )
        {
            OldColor = in_OldColor;
            NewColor = in_NewColor;
        }

        public ColorPair( )
        {

        }
    }
}
