using System.Threading.Tasks;

namespace AceStream.Modules.ChampionatModule
{
    public class ChampionatPresenter : IChampionatPresenter
    {
        public IChampionatInteractor Interactor { get; set; }
        public IChampionatRouter Router { get; set; }
        private IChampionatView _view;

        public ChampionatPresenter(IChampionatView view)
        {
            _view = view;
        }

        public async Task SetChampionatsAsync()
        {
            await _view.SetChampionatsAsync(Interactor.GetChampionatsAsync());
        }

        public void ConfigureView()
        {
            _view.SetSettings(Interactor.Title);
        }

        public void SetError()
        {
            _view.SetErrorView();
        }

        public void SetNotFoundMatches()
        {
            _view.SetNotFoundView();
        }
    }
}
