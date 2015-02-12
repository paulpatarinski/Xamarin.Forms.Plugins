using System.Windows;
using System.Windows.Controls;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.Pages
{
  public partial class NativeListviewControl : UserControl
  {
     private DataTemplate _twoColumnCellDataTemplate;

    public NativeListviewControl()
    {
      InitializeComponent();
    }

    public DataTemplate TwoColumnCellTemplate
    {
      get
      {
        if (_twoColumnCellDataTemplate == null)
        {
          _twoColumnCellDataTemplate = NativeLongListSelector.ItemTemplate;
        }

        return _twoColumnCellDataTemplate;
      }
    }
  }
}
