using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.iOS.Modules.MatchModule
{
    public interface IMatchConfigurator
    {
        void Configure(IMatchView view);
    }

    public interface IMatchPresenter
    {
        int MatchId { get; set; }
        string Title { get; set; }

        Task SetMatchAsync();
        void SetError();
        void ConfigureView();

        void PrepareForSegue(object destinationView, string link);
    }

    public interface IMatchInteractor
    {
        Task<MatchDto> GetMatchAsync(int matchId);
    }

    public interface IMatchRouter
    {
        void PrepareForSegue(object destinationView, string link);
    }

    public interface IMatchView
    {
        IMatchPresenter Presenter { get; set; }

        void SetSettings(string title);
        void SetMatch(MatchDto dto);
        void SetError();
    }
}
