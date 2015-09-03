using System.Reflection;
using Xamarin.Forms;

namespace SVG.Forms.Plugin.Abstractions
{
  public class SvgImage : Image
  {
      private bool _IsTemplateLoaded          = false;

        #region Properties
        /// <summary>
        /// The path to the svg file
        /// </summary>
        public static readonly BindableProperty SvgPathProperty = BindableProperty.Create("SvgPath", typeof(string), typeof(SvgImage), default(string));

        /// <summary>
        /// The path to the svg file
        /// </summary>
        public string SvgPath
        {
            get { return (string)GetValue(SvgPathProperty); }
            set { SetValue(SvgPathProperty, value); }
        }

        /// <summary>
        /// The assembly containing the svg file
        /// </summary>
        public static readonly BindableProperty SvgAssemblyProperty = BindableProperty.Create("SvgAssembly", typeof(Assembly), typeof(SvgImage), default(Assembly));

        /// <summary>
        /// The assembly containing the svg file
        /// </summary>
        public Assembly SvgAssembly
        {
            get { return (Assembly)GetValue(SvgAssemblyProperty); }
            set { SetValue(SvgAssemblyProperty, value); }
        }

        /// <summary>
        /// Colors to replace upon render.
        /// </summary>
        public static readonly BindableProperty ReplacementColorsProperty = BindableProperty.Create<SvgImage, ColorPairs>(w => w.ReplacementColors, null, BindingMode.Default, null, OnReplacementColorsPropertyChanged, null, null, null);
        /// <summary>
        /// Colors to replace upon render.
        /// </summary>
        public ColorPairs ReplacementColors
        {
            get { return (ColorPairs)GetValue(ReplacementColorsProperty); }
            set { SetValue(ReplacementColorsProperty, value); }
        }
        #endregion

        #region Startup
        public SvgImage( ) : base( )
        {
            if( ReplacementColors == null )
                ReplacementColors = new ColorPairs( );

            ApplyTemplate( );
        }

        private void ApplyTemplate( )
        {
            _IsTemplateLoaded = true;
            OnReplacementColorsChanged( );
        }
        #endregion

        #region Property Changes
        private static void OnReplacementColorsPropertyChanged( BindableObject d, ColorPairs in_OldValue, ColorPairs in_NewValue )
        {
            SvgImage element = d as SvgImage;

            if( element == null )
                return;

            if( in_OldValue != null )
                in_OldValue.CollectionChanged -= element.ColorPairs_CollectionChanged;

            if( in_NewValue != null )
            {
                in_NewValue.CollectionChanged -= element.ColorPairs_CollectionChanged;
                in_NewValue.CollectionChanged += element.ColorPairs_CollectionChanged;
            }

            if( in_NewValue == in_OldValue )
                return;

            element.OnReplacementColorsChanged( );
        }

        private void ColorPairs_CollectionChanged( object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e )
        {
            // inefficient for now, should go by whats added and what is not --bwc
            OnReplacementColorsChanged( );
        }

        private void OnReplacementColorsChanged( )
        {
            if( !_IsTemplateLoaded )
                return;

            //ISvgImageRenderer renderer = RendererFactory.GetRenderer(this) as ISvgImageRenderer;
            //if( renderer != null )
            //    renderer.Render( );
        }
        #endregion
  }
}