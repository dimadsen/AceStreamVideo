using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.iOS.Modules.ChampionatModule
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

        public void PrepareForSegue(object destinationView, ChampionatDto dto)
        {
            Router.PrepareForSegue(destinationView, dto);
        }

        public async Task SetChampionatsAsync()
        {
            var championats = await Interactor.GetChampionatsAsync();

            _view.SetChampionats(championats);
        }

        public void ConfigureView()
        {
            _view.SetSettings(Interactor.Title);
        }

        public void SetError()
        {
            _view.SetErrorView();
        }

        public void SetNotFoundChampionats(string message)
        {
            _view.SetNotFoundView(message);
        }
    }
}
