using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using Foundation;
using UIKit;

namespace AceStream.Modules.ChampionatModule
{
    public interface IChampionatConfigurator
    {
        void Configure(ChampionatViewController viewController);
    }

    public interface IChampionatPresenter
    {
        IChampionatRouter Router { get; set; }
        IChampionatInteractor Interactor { get; set; }

        Task SetChampionatsAsync();
        void SetError();
        void ConfigureView();
    }

    public interface IChampionatInteractor
    {
        string Title { get; }
        Task<List<ChampionatDto>> GetChampionatsAsync();
    }

    public interface IChampionatRouter
    {
        void Prepare(UIStoryboardSegue segue, int sender);
    }

    public interface IChampionatView
    {
        void SetSettings(string title);
        Task SetChampionatsAsync(Task<List<ChampionatDto>> championats);
        void SetErrorView();  
    }

}
