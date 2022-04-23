using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services.Dto;

namespace AceStream.iOS.Modules.SquardModule
{
    public interface ISquardConfigurator
    {
        void Configure(ISquardView view);
    }

    public interface ISquardPresenter
    {
        int MatchId { get; set; }

        void ConfigureView(ISquardView view);
        Task SetPlayersAsync();
    }

    public interface ISquardInteractor
    {
        Task<SquardDto> GetSquardsAsync(int matchId);
    }    

    public interface ISquardView
    {
        ISquardPresenter Presenter { get; set; }

        void SetSettings();
        void SetPlayers(SquardDto players);
        void SetTableSquard();
        void SetNotFoundPlayers();
    }
}
