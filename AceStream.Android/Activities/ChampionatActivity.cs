
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Android.Adapters;
using AceStream.Dto;
using AceStream.iOS.Modules.ChampionatModule;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Xamarin.Essentials;

namespace AceStream.Android
{
    [Activity(Label = "ChampionatActivity", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class ChampionatActivity : Activity, IChampionatView
    {
        public IChampionatPresenter _presenter { get; set; }

        private List<ChampionatDto> _championatsDto;

        private ListView _championatsList;

        private string _title;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Startup.Start();

            var configurator = new ChampionatConfigurator();
            configurator.Configure(this);
        }

        protected override void OnStart()
        {
            base.OnStart();

            _presenter.ConfigureView();

            Task.Run(async () =>
            {
                await _presenter.SetChampionatsAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    SetContentView(Resource.Layout.ChampionatLayout);

                    _championatsList = FindViewById<ListView>(Resource.Id.championats);
                    _championatsList.Adapter = new ChampionatAdapter(this, _championatsDto);

                    _championatsList.ItemClick += PrepareForSegue;

                    var text = FindViewById<TextView>(Resource.Id.tabBarText);

                    text.Text = _title;
                });
            });
        }

        private void PrepareForSegue(object sender, AdapterView.ItemClickEventArgs e)
        {
            var championat = _championatsDto[e.Position];

            var intent = new Intent(this, typeof(MatchPreviewActivity));

            //TODO: здесь должен быть вызван Presenter, который передаёт в Router экземпляр Activity,
            //а Router инстансирует свойство ChampionatId
            // 
            //Presenter.PrepareForSegue(intent, championat);

            StartActivity(intent);
        }

        public void SetChampionats(List<ChampionatDto> championats)
        {
            _championatsDto = championats;
        }

        public void SetErrorView()
        {
            throw new NotImplementedException();
        }

        public void SetNotFoundView(string message)
        {
            throw new NotImplementedException();
        }

        public void SetSettings(string title)
        {
            _title = title;
        }
    }
}
