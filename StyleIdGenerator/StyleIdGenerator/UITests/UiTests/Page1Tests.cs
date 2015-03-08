using System.Linq;
using NUnit.Framework;
using UiTests.ExtensionsMethods;

namespace UiTests
{
    public partial class CrossPlatformTests
    {
        [Test]
        public void MainTextLabel_ShouldBeSelectable()
        {
            var lblMainText = _app.Query(StyleIds.Page1.lblMainText);

            Assert.IsNotNull(lblMainText);
            Assert.IsTrue(lblMainText.Any());
        }

        [Test]
        public void LabelWithSpace_ShouldBeSelectable()
        {
            var lblWithSpace = _app.Query(StyleIds.Page1.lblWithSpace);

            Assert.IsNotNull(lblWithSpace);
            Assert.IsTrue(lblWithSpace.Any());
        }

        [Test]
        public void LabelAllCaps_ShouldBeSelectable()
        {
            var lblAllCaps = _app.Query(StyleIds.Page1.LBLALLCAPS);

            Assert.IsNotNull(lblAllCaps);
            Assert.IsTrue(lblAllCaps.Any());
        }
    }
}
