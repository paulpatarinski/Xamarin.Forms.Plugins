using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using SVG.Forms.Plugin.Abstractions;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows;

namespace SVG.Forms.Plugin.WindowsPhone
{
    public static class SvgImageRendererExtensions
    {
        // Cant get extension working?  Still not needed, just wanted to keep in line with other code.  --bwc
        //public static List<Path> ReplaceColors(this ISvgImageRenderer This, Viewbox in_View, IEnumerable<ColorPair> in_Colors )
        public static List<Path> ReplaceColors( Viewbox in_View, IEnumerable<ColorPair> in_Colors )
        {
            List<Path> ret = new List<Path>( );

            FillList(in_View.Child, ret);

            foreach( Path it in ret )
            {
                ReplaceColor(it.Fill, in_Colors);
                ReplaceColor(it.Stroke, in_Colors);
            }

            return ret;
        }

        public static void ReplaceColor( Brush in_Brush, IEnumerable<ColorPair> in_Colors )
        {
            if( (in_Brush == null) || (in_Colors == null) )
                return;

            if( in_Brush is SolidColorBrush )
            {
                SolidColorBrush brush   = in_Brush as SolidColorBrush;
                double R                = Convert.ToDouble(brush.Color.R / 255.0);
                double G                = Convert.ToDouble(brush.Color.G / 255.0);
                double B                = Convert.ToDouble(brush.Color.B / 255.0);
                double A                = Convert.ToDouble(brush.Color.A / 255.0);
                ColorPair pair          = in_Colors.FirstOrDefault(x => (R == x.OldColor.R) && (G == x.OldColor.G) && (B == x.OldColor.B) && (A == x.OldColor.A));

                if( pair != null )
                    brush.Color = new System.Windows.Media.Color( ) { R=Convert.ToByte(pair.NewColor.R * 255), G=Convert.ToByte(pair.NewColor.G * 255), B=Convert.ToByte(pair.NewColor.B * 255), A=Convert.ToByte(pair.NewColor.A * 255) };
            }
            else if( in_Brush is RadialGradientBrush )
            {
                RadialGradientBrush brush   = in_Brush as RadialGradientBrush;

                foreach( GradientStop stop in brush.GradientStops )
                {
                    ReplaceColor(stop, in_Colors);
                }
            }
            else if( in_Brush is LinearGradientBrush )
            {
                LinearGradientBrush brush   = in_Brush as LinearGradientBrush;
                foreach( GradientStop stop in brush.GradientStops )
                {
                    ReplaceColor(stop, in_Colors);
                }
            }
        }

        public static void ReplaceColor( GradientStop in_Stop, IEnumerable<ColorPair> in_Colors )
        {
            if( (in_Stop == null) || (in_Colors == null) )
                return;

            if( in_Colors.Count( ) == 0 )
                return;

            double R                = Convert.ToDouble(in_Stop.Color.R / 255.0);
            double G                = Convert.ToDouble(in_Stop.Color.G / 255.0);
            double B                = Convert.ToDouble(in_Stop.Color.B / 255.0);
            double A                = Convert.ToDouble(in_Stop.Color.A / 255.0);
            ColorPair pair          = in_Colors.FirstOrDefault(x => (R == x.OldColor.R) && (G == x.OldColor.G) && (B == x.OldColor.B) && (A == x.OldColor.A));

            if( pair != null )
                in_Stop.Color = new System.Windows.Media.Color( ) { R=Convert.ToByte(pair.NewColor.R * 255), G=Convert.ToByte(pair.NewColor.G * 255), B=Convert.ToByte(pair.NewColor.B * 255), A=Convert.ToByte(pair.NewColor.A * 255) };
        }

        public static void FillList( UIElement in_Element, List<Path> out_List )
        {
            if( in_Element == null )
                return;

            if( in_Element is Path )
                out_List.Add(in_Element as Path);

            if( in_Element is Panel )
            {
                foreach( UIElement it in (in_Element as Panel).Children )
                {
                    FillList(it, out_List);
                }
            }
            else if( in_Element is Border )
            {
                FillList((in_Element as Border).Child, out_List);
            }
            else if( in_Element is ContentControl )
            {
                FillList((in_Element as ContentControl).Content as UIElement, out_List);
            }
        }
    }
}
