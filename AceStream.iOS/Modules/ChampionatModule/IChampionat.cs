using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using Foundation;
using UIKit;

namespace AceStream.Modules.ChampionatModule
{
    public interface IChampionatConfigurator
    {
        void Configure(IChampionatView viewController);
    }

    public interface IChampionatPresenter
    {
        void PrepareForSegue(object destinationView, ChampionatDto sender);

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
        void PrepareForSegue(object destinationView, ChampionatDto sender);
    }

    public interface IChampionatView
    {
        IChampionatPresenter Presenter { get; set; }

        void SetSettings(string title);
        Task SetChampionatsAsync(Task<List<ChampionatDto>> championats);
        void SetErrorView();
        void SetNotFoundView();
    }

}
