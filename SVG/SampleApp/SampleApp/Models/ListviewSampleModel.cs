using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Models
{
  public class SampleListviewModel
  {
    private Assembly _svgAssembly;
    public Assembly SvgAssembly
    {
      get {
        if(_svgAssembly == null)
        {
          _svgAssembly = typeof(App).GetTypeInfo().Assembly; 
        }
        return _svgAssembly;
      }
    }

    public string TigerSvgPath
    {
      get { return "SampleApp.Images.tiger.svg"; }
    }
  }
}
