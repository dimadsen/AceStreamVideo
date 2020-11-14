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
        IMatchRouter Router { get; set; }
        IMatchInteractor Interactor { get; set; }

        int MatchId { get; set; }
        string Title { get; set; }

        Task SetMatchAsync();
        void SetError();
        void ConfigureView();
    }

    public interface IMatchInteractor
    {
        Task<MatchDto> GetMatchAsync(int matchId);
    }

    public interface IMatchRouter
    {
        //void Prepare(UIStoryboardSegue segue, string link);
        //SegmentedViewController InitializeSegmented(MatchDto match);
    }

    public interface IMatchView
    {
        IMatchPresenter Presenter { get; set; }

        void SetSettings(string title);
        Task SetMatchAsync(Task<MatchDto> dto);
        void SetError();
    }
}
