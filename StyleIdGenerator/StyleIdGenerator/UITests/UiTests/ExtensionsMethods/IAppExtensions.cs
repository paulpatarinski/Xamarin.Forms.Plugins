using System;
using System.Threading;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UiTests.ExtensionsMethods
{
    public static class IAppExtensionMethods
    {
        /// <summary>
        ///     This methods assumes you are using Marked as a selector
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="styleId">Style identifier.</param>
        /// <param name="timeoutMessage">Timeout message.</param>
        /// <param name="timeout">Timeout.</param>
        /// <param name="retryFrequency">Retry frequency.</param>
        /// <param name="postTimeout">Post timeout.</param>
        public static void WaitForElement(this IApp app, string styleId, string timeoutMessage,
            TimeSpan timeout = default(TimeSpan), TimeSpan retryFrequency = default(TimeSpan),
            TimeSpan postTimeout = default(TimeSpan))
        {
            app.WaitForElement(c => c.Marked(styleId), timeoutMessage, timeout, retryFrequency, postTimeout);
        }

        /// <summary>
        ///     This methods assumes you are using Marked as a selector
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="styleId">Style identifier.</param>
        public static AppResult[] Query(this IApp app, string styleId)
        {
            return app.Query(c => c.Marked(styleId));
        }

        /// <summary>
        ///     This methods assumes you are using Marked as a selector
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="styleId">Style identifier.</param>
        public static void Tap(this IApp app, string styleId)
        {
            app.Tap(c => c.Marked(styleId));
        }

        /// <summary>
        ///     This methods assumes you are using Marked as a selector
        /// </summary>
        /// <param name="app">App.</param>
        /// <param name="styleId">Style identifier.</param>
        /// <param name="text"></param>
        public static void EnterText(this IApp app, string styleId, string text)
        {
            app.EnterText(c => c.Marked(styleId), text);
        }

        public static void Wait(this IApp app, TimeSpan waitTime)
        {
            Thread.Sleep(waitTime);
        }
    }
}