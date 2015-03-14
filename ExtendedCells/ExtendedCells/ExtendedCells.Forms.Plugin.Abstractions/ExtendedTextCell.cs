using Xamarin.Forms;

namespace ExtendedCells.Forms.Plugin.Abstractions
{
  public class ExtendedTextCell : ViewCell
  {
    public static readonly BindableProperty StyleProperty =
      BindableProperty.Create("Style", typeof(Style), typeof(ExtendedTextCell), default(Style), propertyChanged: OnStylePropertyChanged);

    public Style Style
    {
      get { return (Style)GetValue(StyleProperty); }
      set { SetValue(StyleProperty, value); }
    }

    private static void OnStylePropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
    {
      if (newvalue is Style)
      {
        var style = (Style) newvalue;

        if (style.BasedOn != null)
        {
          ApplyStyle(bindable,style.BasedOn );
        }

        ApplyStyle(bindable, style);
      }
      if (newvalue != null )
        return;
    }

    private static void ApplyStyle(BindableObject bindable, Style newvalue)
    {
      foreach (var setter in newvalue.Setters )
      {
          bindable.SetValue(setter.Property, setter.Value);
      }
    }

    public static readonly BindableProperty BackgroundColorProperty =
    BindableProperty.Create("BackgroundColor", typeof(Color), typeof(TextCell), Color.Default);

    public Color BackgroundColor
    {
      get
      {
        return (Color)GetValue(BackgroundColorProperty);
      }
      set
      {
        SetValue(BackgroundColorProperty, value);
      }
    }

    public static readonly BindableProperty ThicknessProperty =
     BindableProperty.Create("Thickness", typeof(Thickness), typeof(ExtendedTextCell), default(Thickness));

    public Thickness Thickness
    {
      get { return (Thickness)GetValue(ThicknessProperty); }
      set { SetValue(ThicknessProperty, value); }
    }

    public static readonly BindableProperty LeftColumnWidthProperty =
    BindableProperty.Create("LeftColumnWidth", typeof(GridLength), typeof(TextCell), new GridLength(0.5, GridUnitType.Star));

    public GridLength LeftColumnWidth
    {
      get
      {
        return (GridLength)GetValue(LeftColumnWidthProperty);
      }
      set
      {
        SetValue(LeftColumnWidthProperty, value);
      }
    }

    public static readonly BindableProperty RightColumnWidthProperty =
   BindableProperty.Create("RightColumnWidth", typeof(GridLength), typeof(TextCell), new GridLength(0.5, GridUnitType.Star));

    public GridLength RightColumnWidth
    {
      get
      {
        return (GridLength)GetValue(RightColumnWidthProperty);
      }
      set
      {
        SetValue(RightColumnWidthProperty, value);
      }
    }

    #region LeftText

    public static readonly BindableProperty LeftTextProperty =
    BindableProperty.Create("LeftText", typeof(string), typeof(ExtendedTextCell), "");

    public string LeftText
    {
      get { return (string)GetValue(LeftTextProperty); }
      set { SetValue(LeftTextProperty, value); }
    }

    public static readonly BindableProperty LeftTextColorProperty =
      BindableProperty.Create("LeftTextColor", typeof(Color), typeof(TextCell), Color.Default);

    public Color LeftTextColor
    {
      get
      {
        return (Color)GetValue(LeftTextColorProperty);
      }
      set
      {
        SetValue(LeftTextColorProperty, value);
      }
    }

    public static readonly BindableProperty LeftTextFontProperty =
    BindableProperty.Create("LeftTextFont", typeof(Font), typeof(ExtendedTextCell), Font.SystemFontOfSize(NamedSize.Medium));

    public Font LeftTextFont
    {
      get { return (Font)GetValue(LeftTextFontProperty); }
      set { SetValue(LeftTextFontProperty, value); }
    }

    public static readonly BindableProperty LeftTextAlignmentProperty =
    BindableProperty.Create("LeftTextAlignment", typeof(TextAlignment), typeof(ExtendedTextCell), default(TextAlignment));

    public TextAlignment LeftTextAlignment
    {
      get { return (TextAlignment)GetValue(LeftTextAlignmentProperty); }
      set { SetValue(LeftTextAlignmentProperty, value); }
    }
    #endregion LeftText

    #region Left Detail

    public static readonly BindableProperty LeftDetailProperty =
      BindableProperty.Create("LeftDetail", typeof(string), typeof(ExtendedTextCell), "");

    public string LeftDetail
    {
      get { return (string)GetValue(LeftDetailProperty); }
      set { SetValue(LeftDetailProperty, value); }
    }

    public static readonly BindableProperty LeftDetailColorProperty =
     BindableProperty.Create("LeftDetailColor", typeof(Color), typeof(TextCell), Color.Default);

    public Color LeftDetailColor
    {
      get
      {
        return (Color)GetValue(LeftDetailColorProperty);
      }
      set
      {
        SetValue(LeftDetailColorProperty, value);
      }
    }

    public static readonly BindableProperty LeftDetailFontProperty =
   BindableProperty.Create("LeftDetailFont", typeof(Font), typeof(ExtendedTextCell), Font.SystemFontOfSize(NamedSize.Medium));

    public Font LeftDetailFont
    {
      get { return (Font)GetValue(LeftDetailFontProperty); }
      set { SetValue(LeftDetailFontProperty, value); }
    }

    public static readonly BindableProperty LeftDetailAlignmentProperty =
   BindableProperty.Create("LeftDetailAlignment", typeof(TextAlignment), typeof(ExtendedTextCell), default(TextAlignment));

    public TextAlignment LeftDetailAlignment
    {
      get { return (TextAlignment)GetValue(LeftDetailAlignmentProperty); }
      set { SetValue(LeftDetailAlignmentProperty, value); }
    }

    #endregion Left Detail

    #region Right Text

    public static readonly BindableProperty RightTextProperty =
     BindableProperty.Create("RightText", typeof(string), typeof(ExtendedTextCell), "");

    public string RightText
    {
      get { return (string)GetValue(RightTextProperty); }
      set { SetValue(RightTextProperty, value); }
    }

    public static readonly BindableProperty RightTextColorProperty =
     BindableProperty.Create("RightTextColor", typeof(Color), typeof(TextCell), Color.Default);

    public Color RightTextColor
    {
      get
      {
        return (Color)GetValue(RightTextColorProperty);
      }
      set
      {
        SetValue(RightTextColorProperty, value);
      }
    }

    public static readonly BindableProperty RightTextFontProperty =
BindableProperty.Create("RightTextFont", typeof(Font), typeof(ExtendedTextCell), Font.SystemFontOfSize(NamedSize.Medium));

    public Font RightTextFont
    {
      get { return (Font)GetValue(RightTextFontProperty); }
      set { SetValue(RightTextFontProperty, value); }
    }

    public static readonly BindableProperty RightTextAlignmentProperty =
  BindableProperty.Create("RightTextAlignment", typeof(TextAlignment), typeof(ExtendedTextCell), default(TextAlignment));

    public TextAlignment RightTextAlignment
    {
      get { return (TextAlignment)GetValue(RightTextAlignmentProperty); }
      set { SetValue(RightTextAlignmentProperty, value); }
    }

    #endregion Right Text

    #region Right Detail

    public static readonly BindableProperty RightDetailProperty =
    BindableProperty.Create("RightDetail", typeof(string), typeof(ExtendedTextCell), "");

    public string RightDetail
    {
      get { return (string)GetValue(RightDetailProperty); }
      set { SetValue(RightDetailProperty, value); }
    }

    public static readonly BindableProperty RightDetailColorProperty =
  BindableProperty.Create("RightDetailColor", typeof(Color), typeof(TextCell), Color.Default);

    public Color RightDetailColor
    {
      get
      {
        return (Color)GetValue(RightDetailColorProperty);
      }
      set
      {
        SetValue(RightDetailColorProperty, value);
      }
    }

    public static readonly BindableProperty RightDetailFontProperty =
BindableProperty.Create("RightDetailFont", typeof(Font), typeof(ExtendedTextCell), Font.SystemFontOfSize(NamedSize.Medium));

    public Font RightDetailFont
    {
      get { return (Font)GetValue(RightDetailFontProperty); }
      set { SetValue(RightDetailFontProperty, value); }
    }

    public static readonly BindableProperty RightDetailAlignmentProperty =
 BindableProperty.Create("RightDetailAlignment", typeof(TextAlignment), typeof(ExtendedTextCell), default(TextAlignment));

    public TextAlignment RightDetailAlignment
    {
      get { return (TextAlignment)GetValue(RightDetailAlignmentProperty); }
      set { SetValue(RightDetailAlignmentProperty, value); }
    }

    #endregion Right Detail
  }
}