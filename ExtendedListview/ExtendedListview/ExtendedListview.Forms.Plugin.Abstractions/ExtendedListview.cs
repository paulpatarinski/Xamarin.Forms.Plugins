using Xamarin.Forms;

namespace ExtendedListview.Forms.Plugin.Abstractions
{
  /// <summary>
  ///   ExtendedListview Interface
  /// </summary>
  public class ExtendedListview : ListView
  {
    private const int DEFAULT_OFFSET = 7;
    private const int DEFAULT_PAGE_SIZE = 10;

    /// <summary>
    /// Command that gets executed when more data needs to be loaded, based on Offset
    /// LoadMoreQuery will have the PageNumber and PageSize
    /// </summary>
    public static readonly BindableProperty LoadMoreCommandProperty =
      BindableProperty.Create("LoadMoreCommand", typeof (Command<LoadMoreQuery>), typeof (ExtendedListview),
        default (Command<LoadMoreQuery>));

    /// <summary>
    /// Command that gets executed when more data needs to be loaded, based on Offset
    /// LoadMoreQuery will have the PageNumber and PageSize
    /// WinPhone : LoadMore command will get called multiple times initially to Preload Data
    /// </summary>
    public Command<LoadMoreQuery> LoadMoreCommand
    {
      get { return (Command<LoadMoreQuery>) GetValue(LoadMoreCommandProperty); }
      set { SetValue(LoadMoreCommandProperty, value); }
    }

    /// <summary>
    ///   Offset from ItemSource.Count before LoadMore Command is executed
    /// </summary>
    public int Offset
    {
      get { return (int) GetValue(OffsetProperty); }
      set { SetValue(OffsetProperty, value); }
    }

    /// <summary>
    ///   The number of records that are displayed for each page of data. The default is 10.
    /// </summary>
    public int PageSize
    {
      get { return (int) GetValue(PageSizeProperty); }
      set { SetValue(PageSizeProperty, value); }
    }

    /// <summary>
    /// Offset from ItemSource.Count before LoadMore Command is executed
    /// The default value is 7.
    /// </summary>
    public static readonly BindableProperty OffsetProperty =
      BindableProperty.Create("Offset", typeof (int), typeof (ExtendedListview), DEFAULT_OFFSET);

    /// <summary>
    /// The number of records that are displayed for each page of data.
    /// The default is 10.
    /// </summary>
    public static readonly BindableProperty PageSizeProperty =
      BindableProperty.Create("PageSize", typeof (int), typeof (ExtendedListview), DEFAULT_PAGE_SIZE);
  }
}