using System;
using System.Threading.Tasks;
using AceStream.iOS.Modules.MatchModule;

namespace AceStream.Modules.MatchModule
{
    public class MatchPresenter : IMatchPresenter
    {
        private IMatchRouter _router { get; set; }
        private IMatchInteractor _interactor { get; set; }
        private IMatchView _view;

        public int MatchId { get; set; }
        public string Title { get; set; }

        public MatchPresenter(IMatchRouter router, IMatchInteractor interactor)
        {
            _router = router;
            _interactor = interactor;
        }

        public void ConfigureView(IMatchView view)
        {
            _view = view;

            _view.SetSettings(Title);
        }

        public async Task SetMatchAsync()
        {
            try
            {
                var match = await _interactor.GetMatchAsync(MatchId);

                _view.SetMatch(match);

            }
            catch (Exception ex)
            {
                _view.SetError();
            }
        }

        public void SetError()
        {
            _view.SetError();
        }

        public void PrepareForSegue(object destinationView, string link)
        {
            _router.PrepareForSegue(destinationView, link);
        }
    }
}
