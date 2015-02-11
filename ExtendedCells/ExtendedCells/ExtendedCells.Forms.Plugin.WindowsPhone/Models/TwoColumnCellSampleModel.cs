using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ExtendedCells.Forms.Plugin.WindowsPhone.Models
{
  public class TwoColumnCellSampleModel
  {
    public string LeftText { get; set; }
    public Color LeftTextColor { get; set; }
    public string LeftDetail { get; set; }
    public Color LeftDetailColor { get; set; }
    public string RightText { get; set; }
    public Color RightTextColor { get; set; }
    public string RightDetail { get; set; }
    public Color RightDetailColor { get; set; }
  }

  public class TwoColumnCellSampleModelCollection : ObservableCollection<TwoColumnCellSampleModel>
  {
    public TwoColumnCellSampleModelCollection()
    {
      Add(new TwoColumnCellSampleModel
      {
        LeftText = "Clock in",
        LeftTextColor = Color.Yellow,
        LeftDetail = "Note goes here",
        LeftDetailColor = Color.Red,
        RightText = "02/01/2015",
        RightTextColor = Color.Purple,
        RightDetail = "09:00 AM",
        RightDetailColor = Color.Lime
      });

      Add(new TwoColumnCellSampleModel
      {
        LeftText = "Clock out lalalalal",
        LeftTextColor = Color.Yellow,
        RightText = "01/15/2013",
        RightTextColor = Color.Purple,
      });
    }
  }
}
