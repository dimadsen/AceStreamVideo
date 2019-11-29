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

        void ConfigureView();
    }

    public interface IChampionatInteractor
    {
        string Title { get; }
        ChampionatDto[] GetChampionats();
    }

    public interface IChampionatRouter
    {
        void Prepare(UIStoryboardSegue segue, int sender);
    }

    public interface IChampionatView
    {
        void SetSettings(string title);
        void SetChampionats(ChampionatDto[] championats);
    }
}
