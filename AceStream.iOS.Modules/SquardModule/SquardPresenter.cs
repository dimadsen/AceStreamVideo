using AceStream.Dto;

namespace AceStream.iOS.Modules.SquardModule
{
    public class SquardPresenter: ISquardPresenter
    {
        public ISquardInteractor Interactor { get; set; }
        public ISquardRouter Router { get; set; }

        public MatchDto Match { get; set; }

        private ISquardView _view;


        public SquardPresenter(ISquardView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetSettings();     
        }

        public void SetPlayers()
        {
            _view.SetPlayers(Interactor.GetMatch(Match));
        }

        public void SetNotFoundPlayers()
        {
            _view.SetNotFoundPlayers();
        }

        public void SetTitleHeader()
        {
            _view.SetTableSquard();
        }
    }
}
