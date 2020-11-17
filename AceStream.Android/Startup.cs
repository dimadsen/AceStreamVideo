using AceStream.Infrastructure.Clients;
using AceStream.Infrastructure.DependencyInjection;
using AceStream.Services;
using AceStream.Services.Clients;
using AceStream.Services.Impl;
using AceStream.Services.Interfaces;

namespace AceStream.Android
{
    public static class Startup
    {
        public static void Start()
        {
            var services = new ServiceCollection();

            services.AddScoped<IClient, SportsRuClient>();

            var client = ServiceCollection.Get<IClient>();

            services.AddScoped<IChampionatService, ChampionatService>(client);
            services.AddScoped<IMatchPreviewService, MatchPreviewService>(client);
            services.AddScoped<IMatchService, MatchService>(client);
            services.AddScoped<ILinkService, LinkService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
