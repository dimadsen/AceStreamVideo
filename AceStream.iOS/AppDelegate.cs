using System;
using AceStream.Infrastructure.Clients;
using AceStream.Infrastructure.Mapping;
using AceStream.iOS.Modules.ChampionatModule;
using AceStream.iOS.Modules.MatchModule;
using AceStream.iOS.Modules.MatchPreviewModule;
using AceStream.iOS.Modules.SquardModule;
using AceStream.iOS.Modules.VideoModule;
using AceStream.Modules.LinkModule;
using AceStream.Modules.MatchModule;
using AceStream.Services;
using AceStream.Services.Clients;
using AceStream.Services.Impl;
using AceStream.Services.Interfaces;
using Foundation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using UIKit;

namespace AceStream
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json", false).Build();
            services.Configure<AceStreamConfiguraiton>(configuration);

            var config = configuration.Get<AceStreamConfiguraiton>();

            services.AddScoped<ISourceClient, SourceClient>();

            services.AddScoped<IChampionatService, ChampionatService>();
            services.AddScoped<IChampionatRouter, ChampionatRouter>();
            services.AddScoped<IChampionatPresenter, ChampionatPresenter>();
            services.AddScoped<IChampionatInteractor, ChampionatInteractor>();

            services.AddScoped<IMatchPreviewService, MatchPreviewService>();
            services.AddScoped<IMatchPreviewRouter, MatchPreviewRouter>();
            services.AddScoped<IMatchPreviewPresenter, MatchPreviewPresenter>();
            services.AddScoped<IMatchPreviewInteractor, MatchPreviewInteractor>();

            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IMatchRouter, MatchRouter>();
            services.AddScoped<IMatchPresenter, MatchPresenter>();
            services.AddScoped<IMatchInteractor, MatchInteractor>();

            services.AddScoped<ISquardPresenter, SquardPresenter>();
            services.AddScoped<ISquardInteractor, SquardInteractor>();

            services.AddScoped<ILinkService, LinkService>();
            services.AddScoped<ILinkRouter, LinkRouter>();
            services.AddScoped<ILinkPresenter, LinkPresenter>();
            services.AddScoped<ILinkInteractor, LinkInteractor>();

            services.AddScoped<IVideoPresenter, VideoPresenter>();

            services.AddRefitClient<ISportsRuClient>(new RefitSettings(new NewtonsoftJsonContentSerializer()))
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(config.ClientUrl);
            });

            var mappingAssemblies = new[]
            {
                typeof(SportsRuMapperProfile).Assembly,
            };

            services.AddAutoMapper(mappingAssemblies);

            ServiceProviderFactory.ServiceProvider = services.BuildServiceProvider();


            return true;
        }
    }
}

