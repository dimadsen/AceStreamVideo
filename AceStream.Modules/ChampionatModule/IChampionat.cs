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
        void PrepareForSegue(object view, ChampionatDto dto);

        Task SetChampionatsAsync();
        void SetError();
        void SetNotFoundChampionats(string message);
        void ConfigureView();
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
        public IChampionatPresenter Presenter { get; set; }

        void SetSettings(string title);
        void SetChampionats(List<ChampionatDto> championats);
        void SetErrorView();
        void SetNotFoundView(string message);
    }
}
