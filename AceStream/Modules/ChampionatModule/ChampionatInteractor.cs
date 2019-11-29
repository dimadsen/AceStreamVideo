using AceStream.Dto;
using AceStream.Services;

namespace AceStream.Modules.ChampionatModule
{
    public class ChampionatInteractor : IChampionatInteractor
    {
        private IChampionatPresenter _presenter;

        private IChampionatService service;

        public ChampionatInteractor(IChampionatPresenter presenter)
        {
            _presenter = presenter;

            service = new ChampionatService();
        }

        public string Title => service.Title;

        public ChampionatDto[] GetChampionats()
        {
            return service.GetChampionats();
        }
    }
}
