using System;
using System.Threading.Tasks;
using AceStream.Core.Exceptions;
using AceStream.Dto;

namespace AceStream.iOS.Modules.MatchPreviewModule
{
    public class MatchPreviewPresenter : IMatchPreviewPresenter
    {
        private IMatchPreviewRouter _router { get; set; }
        private IMatchPreviewInteractor _interactor { get; set; }
        private IMatchPreviewView _view;

        public ChampionatDto Championat { get; set; }

        public MatchPreviewPresenter(IMatchPreviewRouter router, IMatchPreviewInteractor interactor)
        {
            _router = router;
            _interactor = interactor;
        }

        public async Task SetMatchesAsync()
        {
            try
            {
                var matches = await _interactor.GetMatchesAsync(Championat.Id);

                _view.SetMatches(matches);
            }
            catch (MatchesNotFoundException ex)
            {
                _view.SetNotFoundMatches(ex.Message);
            }
            catch (Exception)
            {
                _view.SetError();
            }
        }

        public void ConfigureView(IMatchPreviewView view)
        {
            _view = view;

            _view.SetSettings(_interactor.GetSettings(Championat));
        }

        public void SetError()
        {
            _view.SetError();
        }

        public void PrepareForSegue(object destinationView, int matchId, string title)
        {
            _router.PrepareForSegue(destinationView, matchId, title);
        }

        public void SetNotFoundMatches(string message)
        {
            _view.SetNotFoundMatches(message);
        }
    }
}
