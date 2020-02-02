using System;
using System.Text.RegularExpressions;
using AceStream.Dto;

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

    }

    public interface IMatchView
    {
        void SetSettings();
        void SetMatch(MatchDto dto);
    }
}
