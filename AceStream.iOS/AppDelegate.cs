using System;
using AceStream.Infrastructure.Client;
using AceStream.Infrastructure.DependencyInjection;
using AceStream.Services;
using AceStream.Services.Repositories;
using Foundation;
using UIKit;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }
        
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            #region
            var services = new ServiceCollection();

            services.AddScoped<IClient, Client>();

            var client = Get<IClient>();

            services.AddScoped<IChampionatService, ChampionatService>(client);
            services.AddScoped<IMatchPreviewService, MatchPreviewService>(client);
            services.AddScoped<IMatchService, MatchService>(client);

            #endregion

            return true;
        }

        public override void OnActivated(UIApplication application)
        {
            Console.WriteLine("OnActivated called, App is active.");
        }

        public override void WillEnterForeground(UIApplication application)
        {
            Console.WriteLine("App will enter foreground");
        }

        public override void OnResignActivation(UIApplication application)
        {
            Console.WriteLine("OnResignActivation called, App moving to inactive state.");
        }

        public override void DidEnterBackground(UIApplication application)
        {
            Console.WriteLine("App entering background state.");
        }

        // not guaranteed that this will run
        public override void WillTerminate(UIApplication application)
        {
            Console.WriteLine("App is terminating.");
        }
    }
}

