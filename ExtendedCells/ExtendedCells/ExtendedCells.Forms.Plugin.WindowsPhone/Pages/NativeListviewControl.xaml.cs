using System.Windows;
using System.Windows.Controls;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.Pages
{
  public partial class NativeListviewControl : UserControl
  {
     private DataTemplate _extendedTextCellDataTemplate;

    public NativeListviewControl()
    {
      InitializeComponent();
    }

    public DataTemplate ExtendedTextCellTemplate
    {
      get
      {
        if (_extendedTextCellDataTemplate == null)
        {
          _extendedTextCellDataTemplate = NativeLongListSelector.ItemTemplate;
        }

        return _extendedTextCellDataTemplate;
      }
    }
  }
}
