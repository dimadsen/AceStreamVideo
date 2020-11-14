using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;

namespace AceStream.iOS.Modules.MatchPreviewModule
{
    public interface IMatchPreviewConfigurator
    {
        void Configure(IMatchPreviewView view);
    }

    public interface IMatchPreviewPresenter
    {
        void PrepareForSegue(object destinationView, int matchId, string title);

        ChampionatDto Championat { get; set; }

        Task SetMatchesAsync();
        void SetError();
        void ConfigureView();
        void SetNotFoundMatches(string message);
    }

    public interface IMatchPreviewInteractor
    {
        Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId);

        MatchPreviewSettingsDto GetSettings(ChampionatDto championat);
    }

    public interface IMatchPreviewRouter
    {
        void PrepareForSegue(object destinationView, int matchId, string title);
    }

    public interface IMatchPreviewView
    {
        IMatchPreviewPresenter Presenter { get; set; }

        void SetSettings(MatchPreviewSettingsDto dto);
        Task SetMatchesAsync(Task<List<MatchPreviewDto>> matches);
        void SetNotFoundMatches(string message);
        void SetErrorView();
    }
}
