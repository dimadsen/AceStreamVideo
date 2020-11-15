
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Infrastructure.Clients;
using AceStream.Infrastructure.DependencyInjection;
using AceStream.iOS.Modules.ChampionatModule;
using AceStream.Services;
using AceStream.Services.Clients;
using AceStream.Services.Impl;
using AceStream.Services.Interfaces;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace AceStream.Android
{
    [Activity(Label = "ChampionatActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class ChampionatActivity : Activity, IChampionatView
    {
        public IChampionatPresenter Presenter { get; set; }

        private List<ChampionatDto> _championats;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Start();

            var configurator = new ChampionatConfigurator();
            configurator.Configure(this);
        }

        protected override void OnStart()
        {
            base.OnStart();

            Presenter.ConfigureView();
            Task.Run(async () =>
            {
                await Presenter.SetChampionatsAsync();

                //MainThread.BeginInvokeOnMainThread(() =>
                //{
                    
                //});
            });
        }

        public void SetChampionats(List<ChampionatDto> championats)
        {
            _championats = championats;
        }

        public void SetErrorView()
        {
            //throw new NotImplementedException();
        }

        public void SetNotFoundView(string message)
        {
            //throw new NotImplementedException();
        }

        public void SetSettings(string title)
        {
            
        }

        private void Start()
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
