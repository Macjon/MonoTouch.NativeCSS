using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.NativeCSS;

namespace Samples
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        private UIWindow window;
        private MyViewController viewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            viewController = new MyViewController();
            window.RootViewController = viewController;

            window.MakeKeyAndVisible();

            // NativeCSS is required one license per each bundle id.

            // sample
            //http://localhost:8000/styles.css
            // To live edit, cd to styles.css and run "python -m SimpleHTTPServer"
            var url = new NSUrl("http://macjon.local:8000/styles.css");
            CSSUIApplication.StyleWithCSSFileAndUrl("styles.css", url, 1);
//            CSSUIApplication.UpdateCSSFromURL(url, 1, ((bool success, bool cssIsDifferent, string cssContent) =>
//            {
//                Console.WriteLine("Succes: {0}\nCssIsDifferent: {1}\nCssContent: {2}", success, cssIsDifferent, cssContent);
//            }));

//            CSSUIApplication.StyleWithCSSString("button { background-color: #ff0000; }");

            // sample
            //MonoTouch.NativeCSS.CSSUIApplication.UpdateCSSFromURL(new NSUrl("http", "your ip address", "/path/filename.css"), 3, delegate(bool success, bool different, string content)
            //{
            //	if (success && different) {
            //		MonoTouch.NativeCSS.CSSUIApplication.StyleWithCSSString(content);
            //	} else if (!success) {
            //		MonoTouch.NativeCSS.CSSUIApplication.StyleWithCSSString("button { background-color: #a1a1a1; }");
            //	}
            //});

            // sample
            //var myHandler = new MonoTouch.NativeCSS.UpdateCSSFromURLHandler((bool success, bool different, string content) => { if (success) { } });
            //MonoTouch.NativeCSS.CSSUIApplication.UpdateCSSFromURL(new NSUrl("http", "your ip address", "/path/filename.css"), myHandler);

            return true;
        }
    }
}