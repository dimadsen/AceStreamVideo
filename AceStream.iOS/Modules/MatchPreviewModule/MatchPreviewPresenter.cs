using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.iOS.Modules.MatchPreviewModule;

namespace AceStream.Modules.MatchPreviewModule
{
    public class MatchPreviewPresenter : IMatchPreviewPresenter
    {
        public IMatchPreviewRouter Router { get; set; }
        public IMatchPreviewInteractor Interactor { get; set; }
        private IMatchPreviewView _view;

        public ChampionatDto Championat { get; set; }

        public MatchPreviewPresenter(IMatchPreviewView view)
        {
            _view = view;
        }

        public async Task SetMatchesAsync()
        {
            await _view.SetMatchesAsync(Interactor.GetMatchesAsync(Championat.Id));
        }

        public void ConfigureView()
        {
            _view.SetSettings(Interactor.GetSettings(Championat));
        }

        public void SetError()
        {
            _view.SetErrorView();
        }
    }
}
