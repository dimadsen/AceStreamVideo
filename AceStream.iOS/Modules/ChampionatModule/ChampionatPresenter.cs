using System.Threading.Tasks;
using AceStream.Dto;

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
            var championats = Interactor.GetChampionatsAsync();

            await _view.SetChampionatsAsync(championats);
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

        public void PrepareForSegue(object destinationView, ChampionatDto sender)
        {
            Router.PrepareForSegue(destinationView, sender);
        }
    }
}
