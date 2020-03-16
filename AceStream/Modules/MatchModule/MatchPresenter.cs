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
            _view.SetMatch(Interactor.GetMatch(MatchId));

        }
    }
}
