using NGraphics.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using NGraphics;
using NGraphics.Models.Brushes;
using NGraphics.Interfaces;
using NGraphics.Models.Elements;

namespace SVG.Forms.Plugin.Abstractions
{
    public static class SvgImageRendererExtensions
    {
        public static void ReplaceColors( this ISvgImageRenderer This, Graphic in_Graphic, IEnumerable<ColorPair> in_Colors  )
        {
            if( (in_Colors == null) || (in_Graphic == null) )
                return;

            if( in_Colors.Count() == 0 )
                return;

            if( in_Graphic != null )
            {
                foreach( NGraphics.Interfaces.IDrawable it in in_Graphic.Children )
                {
                    if( it is NGraphics.Models.Elements.Path )
                        ReplaceColor(it as Path, in_Colors);
                    else if( it is NGraphics.Models.Elements.Group )
                        ReplaceColor(it as Group, in_Colors);
                }
            }
        }

        private static void ReplaceColor( Group in_Group, IEnumerable<ColorPair> in_Colors )
        {
            if( in_Group.Brush != null )
                ReplaceColor(in_Group.Brush, in_Colors);

            if( in_Group.Children.Count() == 0 )
                return;

            foreach( NGraphics.Interfaces.IDrawable it in in_Group.Children )
            {
                if( it is Group )
                    ReplaceColor(it as Group, in_Colors);
                else if( it is Path )
                    ReplaceColor((it as Path), in_Colors);
            }
        }

        private static void ReplaceColor( Path in_Path, IEnumerable<ColorPair> in_Colors )
        {
            if( (in_Path == null) || (in_Colors == null) )
                return;

            ReplaceColor(in_Path.Brush, in_Colors);
        }

        private static void ReplaceColor( BaseBrush in_Brush, IEnumerable<ColorPair> in_Colors )
        {
            if( (in_Brush == null) || (in_Colors == null) )
                return;

            if( in_Colors.Count( ) == 0 )
                return;

            if( in_Brush is NGraphics.Models.Brushes.GradientBrush )
            {
                GradientBrush typedBrush = in_Brush as GradientBrush;
                foreach( GradientStop stop in typedBrush.Stops )
                {
                    ColorPair pair = in_Colors.FirstOrDefault(x => (stop.Color.Red == x.OldColor.R) && (stop.Color.Green == x.OldColor.G) && (stop.Color.Blue == x.OldColor.B) && (stop.Color.Alpha == x.OldColor.A));
                    if( pair != null )
                        stop.Color = new NGraphics.Models.Color(pair.NewColor.R, pair.NewColor.G, pair.NewColor.B, pair.NewColor.A);
                }
            }
            else if( in_Brush is NGraphics.Models.Brushes.SolidBrush )
            {
                SolidBrush typedBrush = in_Brush as SolidBrush;
                ColorPair pair = in_Colors.FirstOrDefault(x => (typedBrush.Color.Red == x.OldColor.R) && (typedBrush.Color.Green == x.OldColor.G) && (typedBrush.Color.Blue == x.OldColor.B) && (typedBrush.Color.Alpha == x.OldColor.A));
                if( pair != null )
                    typedBrush.Color = new NGraphics.Models.Color(pair.NewColor.R, pair.NewColor.G, pair.NewColor.B, pair.NewColor.A);
            }
        }
    }
}
