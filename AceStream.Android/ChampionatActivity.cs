
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

        private List<ChampionatDto> _championatsDto;

        private ListView _championatsList;

        private string _title;

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

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    SetContentView(Resource.Layout.ChampionatLayout);
                    _championatsList = FindViewById<ListView>(Resource.Id.championats);
                    _championatsList.Adapter = new ChampionatAdapter(this, _championatsDto);

                    //var text = FindViewById<TextView>(Resource.Id.title);
                });
            });
        }

        public void SetChampionats(List<ChampionatDto> championats)
        {
            _championatsDto = championats;
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
            _title = title;
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

    public class ChampionatAdapter : BaseAdapter<ChampionatDto>
    {
        List<ChampionatDto> _championats;
        Activity _context;

        public ChampionatAdapter(Activity context, List<ChampionatDto> championats) : base()
        {
            _context = context;
            _championats = championats;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get { return _championats.Count; }
        }

        public override ChampionatDto this[int position]
        {
            get { return _championats[position]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var championat = _championats[position];

            var view = convertView;

            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Resource.Layout.championat_list_item, null);
            }
            view.FindViewById<TextView>(Resource.Id.name).Text = championat.Name;
            view.FindViewById<TextView>(Resource.Id.country).Text = championat.Country;

            var id = Resource.Drawable.nationLeague2;
            view.FindViewById<ImageView>(Resource.Id.icon).SetImageResource(id);

            return view;
        }
    }
}
