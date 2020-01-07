using AceStream.Dto.SettingsDto;

namespace AceStream.Modules.MatchPreviewModule
{
    public class MatchPreviewPresenter : IMatchPreviewPresenter
    {

        public IMatchPreviewRouter Router { get; set; }
        public IMatchPreviewInteractor Interactor { get; set; }
        private IMatchPreviewView _view;

        public int ChampionatId { get; set; }

        public MatchPreviewPresenter(IMatchPreviewView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetMatches(Interactor.GetMatches(ChampionatId));
            _view.SetSettings(Interactor.GetSettings(ChampionatId));
        }

    }
}
