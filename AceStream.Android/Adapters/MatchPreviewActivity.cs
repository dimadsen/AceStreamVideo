
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.iOS.Modules.MatchPreviewModule;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace AceStream.Android.Adapters
{
    [Activity(Label = "MatchPreviewActivity")]
    public class MatchPreviewActivity : Activity, IMatchPreviewView
    {
        public IMatchPreviewPresenter Presenter { get; set; }

        private List<MatchPreviewDto> _matches;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var configurator = new MatchPreviewConfigurator();
            configurator.Configure(this);
        }

        protected override void OnStart()
        {
            base.OnStart();

            Presenter.ConfigureView();

            Task.Run(async () =>
            {
                await Presenter.SetMatchesAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    //TODO: Отображение на вьюхе матчей
                });
            });
        }
        public void SetError()
        {
            throw new NotImplementedException();
        }

        public void SetMatches(List<MatchPreviewDto> matches)
        {
            _matches = matches;
        }

        public void SetNotFoundMatches(string message)
        {
            throw new NotImplementedException();
        }

        public void SetSettings(MatchPreviewSettingsDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
