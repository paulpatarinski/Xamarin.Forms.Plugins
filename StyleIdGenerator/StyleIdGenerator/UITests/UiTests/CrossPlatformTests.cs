using NUnit.Framework;
using Xamarin.UITest;

namespace UiTests
{
    public partial class CrossPlatformTests
    {
        public  IApp _app;

        /// <summary>
        ///     We do 'Ignore' in the base class so that these set of tests aren't actually *run*
        ///     outside the context of one of the platform-specific bootstrapper sub-classes.
        /// </summary>
        [SetUp]
        public virtual void SetUp()
        {
            Assert.Ignore("This class requires a platform-specific bootstrapper to override the `SetUp` method");
        }
    }
}