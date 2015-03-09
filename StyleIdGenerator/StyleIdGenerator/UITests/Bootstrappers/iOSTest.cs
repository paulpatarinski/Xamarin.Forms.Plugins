using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Xamarin.UITest;

namespace UiTests.Bootstrappers
{
    /// <summary>
    ///     iOS bootstrapper for the shared Xamarin.Forms tests
    /// </summary>
    [TestFixture]
    public class iOSTest : CrossPlatformTests
    {
        [SetUp]
        public override void SetUp()
        {
            // an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
            // this works fine for local simulator testing though
            _app = ConfigureApp.iOS.AppBundle(PathToIPA).ApiKey("YOUR_API_KEY_HERE").StartApp();
        }

        public string PathToIPA { get; set; }

        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var fi = new FileInfo(currentFile);
            string dir = fi.Directory.Parent.Parent.Parent.FullName;
            PathToIPA = Path.Combine(dir, "iOS", "bin", "iPhoneSimulator", "Debug", "UITestDemoiOS.app");
        }
    }
}