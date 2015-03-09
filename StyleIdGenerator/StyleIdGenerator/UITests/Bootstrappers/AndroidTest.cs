using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Xamarin.UITest;

namespace UiTests.Bootstrappers
{
    /// <summary>
    ///     Android bootstrapper for the shared Xamarin.Forms tests
    /// </summary>
    [TestFixture]
    public class AndroidTest : CrossPlatformTests
    {
        [SetUp]
        public override void SetUp()
        {
            // an API key is required to publish on Xamarin Test Cloud for remote, multi-device testing
            // this works fine for local simulator testing though
            _app = ConfigureApp.Android.ApkFile(PathToAPK).ApiKey("YOUR_API_KEY_HERE").StartApp();
        }

        public string PathToAPK { get; set; }


        [TestFixtureSetUp]
        public void TestFixtureSetup()
        {
            string currentFile = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            var fi = new FileInfo(currentFile);
            string dir = fi.Directory.Parent.Parent.Parent.FullName;
            PathToAPK = Path.Combine(dir, "Android", "bin", "Debug", "UITestDemo.Android.apk");
        }
    }
}