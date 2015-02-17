using System;
using System.Collections;
using System.Windows;
using ExtendedListview.Forms.Plugin.Abstractions;
using ExtendedListview.Forms.Plugin.WindowsPhone;
using Microsoft.Phone.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly:
  ExportRenderer(typeof (ExtendedListview.Forms.Plugin.Abstractions.ExtendedListview), typeof (ExtendedListviewRenderer)
    )]

namespace ExtendedListview.Forms.Plugin.WindowsPhone
{
  /// <summary>
  ///   ExtendedListview Renderer
  ///   http://blogs.windows.com/buildingapps/2012/10/01/how-to-create-an-infinite-scrollable-list-with-longlistselector/
  /// </summary>
  public class ExtendedListviewRenderer : ListViewRenderer
  {
    private int _pageNumber = 1;
    private Abstractions.ExtendedListview _formsControl;
    public Abstractions.ExtendedListview FormsControl
    {
      get { return _formsControl ?? (_formsControl = (Abstractions.ExtendedListview) Element); }
    }

    /// <summary>
    ///   Used for registration with dependency service
    /// </summary>
    public static void Init()
    {
    }

    protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
    {
      base.OnElementChanged(e);
      
      Control.ItemRealized += ControlOnItemRealized;
      Control.Loaded += ControlOnLoaded;
    }

    private void ControlOnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
      FormsControl.LoadMoreCommand.Execute(new LoadMoreQuery
      {
        PageNumber = _pageNumber,
        PageSize = FormsControl.PageSize
      });
    }

    private void ControlOnItemRealized(object sender, ItemRealizationEventArgs e)
    {
      var itemContent = e.Container.Content as Cell;
      
      if (itemContent == null)
        throw new Exception("You have to use a Cell for the ExtendedListview.ItemTemplate DataTemplate");

      var item = itemContent.BindingContext;
      var items = FormsControl.ItemsSource as IList;
      
      if(items == null)
        throw new Exception("ExtendedListview ItemsSource has to be IList");

      var currentItemIndex = items.IndexOf(item);

      if ((items.Count - currentItemIndex <= FormsControl.Offset) && (FormsControl.LoadMoreCommand != null) &&
          (FormsControl.LoadMoreCommand.CanExecute(null)))
      {
        _pageNumber = _pageNumber + 1;
        FormsControl.LoadMoreCommand.Execute(new LoadMoreQuery
        {
          PageNumber = _pageNumber,
          PageSize = FormsControl.PageSize 
        });
      }
    }
  }
}