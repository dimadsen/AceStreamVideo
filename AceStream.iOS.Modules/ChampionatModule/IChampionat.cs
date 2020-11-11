using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.iOS.Modules.MatchPreviewModule;

namespace AceStream.iOS.Modules.ChampionatModule
{
    public interface IChampionatConfigurator
    {
        void Configure(IChampionatView viewController);
    }

    public interface IChampionatPresenter
    {
        IChampionatRouter Router { get; set; }
        IChampionatInteractor Interactor { get; set; }

        Task SetChampionatsAsync();
        void SetError();
        void SetNotFoundMatches();
        void ConfigureView();
    }

    public interface IChampionatInteractor
    {
        string Title { get; }
        Task<List<ChampionatDto>> GetChampionatsAsync();
    }

    public interface IChampionatRouter
    {
        void Prepare(IMatchPreviewView destinationView, ChampionatDto championat);
    }

    public interface IChampionatView
    {
        public IChampionatPresenter Presenter { get; set; }
        public IChampionatConfigurator Configurator { get; set; }

        void SetSettings(string title);
        Task SetChampionatsAsync(Task<List<ChampionatDto>> championats);
        void SetErrorView();
        void SetNotFoundView();
    }
}
