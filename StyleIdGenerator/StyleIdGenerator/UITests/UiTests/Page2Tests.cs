using System.Linq;
using NUnit.Framework;
using UiTests.ExtensionsMethods;

namespace UiTests
{
    public partial class CrossPlatformTests
    {
        [Test]
        public void LabelPage2_ShouldBeSelectable()
        {
            var lblPage2 = _app.Query(StyleIds.Page2.lblPage2);

            Assert.IsNotNull(lblPage2);
            Assert.IsTrue(lblPage2.Any());
        }

      
    }
}
