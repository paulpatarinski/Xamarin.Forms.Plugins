using System.Linq;
using NUnit.Framework;
using UiTests.ExtensionsMethods;
using Xamarin.UITest.Queries;

namespace UiTests
{
    public partial class CrossPlatformTests
    {
        [Test]
        public void LabelPage2_ShouldBeSelectable()
        {
            AppResult[] lblPage2 = _app.Query(StyleIds.Page2.lblPage2);

            Assert.IsNotNull(lblPage2);
            Assert.IsTrue(lblPage2.Any());
        }
    }
}