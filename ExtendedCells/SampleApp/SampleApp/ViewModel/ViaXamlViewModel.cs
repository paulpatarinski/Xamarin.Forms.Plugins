using System.Reflection;

namespace SampleApp.ViewModel
{
  public class ViaXamlViewModel
  {
    public Assembly SvgAssembly
    {
      get { return typeof (App).GetTypeInfo().Assembly; }
    }

    public string CoolMaskSvgPath
    {
      get { return "SampleApp.Images.CoolMask.svg"; }
    }

    public string ElvisSvgPath
    {
      get { return "SampleApp.Images.Elvis.svg"; }
    }

    public string TigerSvgPath
    {
      get { return "SampleApp.Images.tiger.svg"; }
    }

  }
}
