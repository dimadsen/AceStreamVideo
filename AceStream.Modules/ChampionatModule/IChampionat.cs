using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.iOS.Modules.ChampionatModule
{
    public interface IChampionatConfigurator
    {
        void Configure(IChampionatView view);
    }

    public interface IChampionatPresenter
    {
        void PrepareForSegue(object destinationView, ChampionatDto sender);

        Task SetChampionatsAsync();
        void SetError();
        void SetNotFoundChampionats(string message);
        void ConfigureView(IChampionatView view);
    }

    public interface IChampionatInteractor
    {
        Task<List<ChampionatDto>> GetChampionatsAsync();
    }

    public interface IChampionatRouter
    {
        void PrepareForSegue(object destinationView, ChampionatDto championat);
    }

    public interface IChampionatView
    {
        void SetSettings(string title);
        void SetChampionats(List<ChampionatDto> championats);
        void SetErrorView();
        void SetNotFoundView(string message);
    }
}
