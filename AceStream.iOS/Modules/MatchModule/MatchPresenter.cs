using System.Threading.Tasks;
using AceStream.iOS.Modules.MatchModule;

namespace AceStream.Modules.MatchModule
{
    public class MatchPresenter : IMatchPresenter
    {
        public IMatchRouter Router { get; set; }
        public IMatchInteractor Interactor { get; set; }

        public int MatchId { get; set; }
        public string Title { get; set; }

        private IMatchView _view;

        public MatchPresenter(IMatchView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetSettings(Title);
        }

        public async Task SetMatchAsync()
        {
           await _view.SetMatchAsync(Interactor.GetMatchAsync(MatchId));
        }

        public void SetError()
        {
            _view.SetError();
        }
    }
}
