using AceStream.Modules.LoginModule;
using Foundation;
using UIKit;

namespace AceStream
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }
        
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            if (!User.IsAuthorized)
            {
                Window = new UIWindow(UIScreen.MainScreen.Bounds);
                var storyboard = UIStoryboard.FromName("Main", null);

                Window.RootViewController = storyboard.InstantiateViewController("LoginViewController");
                Window.MakeKeyAndVisible();
            }

            return true;
        }
        
    }
}

