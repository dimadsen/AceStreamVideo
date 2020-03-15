using AceStream.Dto;
using UIKit;

namespace AceStream.Modules.MatchModule
{
    public interface IMatchConfigurator
    {
        void Configure(MatchViewController controller);
    }

    public interface IMatchPresenter
    {
        IMatchRouter Router { get; set; }
        IMatchInteractor Interactor { get; set; }
        int MatchId { get; set; }

        void ConfigureView();
    }

    public interface IMatchInteractor
    {
        MatchDto GetMatch(int matchId);
    }

    public interface IMatchRouter
    {
        void Prepare(UIStoryboardSegue segue, string link);
        SegmentedViewController InitializeSegmented(MatchDto match);
    }

    public interface IMatchView
    {
        void SetSettings();
        void SetMatch(MatchDto dto);        
    }
}
