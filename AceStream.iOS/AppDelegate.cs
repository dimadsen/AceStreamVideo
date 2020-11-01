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
            var services = new ServiceCollection();

            services.AddScoped<IClient, Client>();

            var client = Get<IClient>();

            services.AddScoped<IChampionatService, ChampionatService>(client);
            services.AddScoped<IMatchPreviewService, MatchPreviewService>(client);
            services.AddScoped<IMatchService, MatchService>(client);

            return true;
        }
        
    }
}

