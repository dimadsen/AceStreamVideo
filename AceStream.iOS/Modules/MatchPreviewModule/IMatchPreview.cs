using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using UIKit;

namespace AceStream.Modules.MatchPreviewModule
{
    public interface IMatchPreviewConfigurator
    {
        void Configure(MatchPreviewViewController viewController);
    }

    public interface IMatchPreviewPresenter
    {
        IMatchPreviewRouter Router { get; set; }
        IMatchPreviewInteractor Interactor { get; set; }
        ChampionatDto Championat { get; set; }

        Task SetMatchesAsync();
        void SetError();
        void ConfigureView();        
    }

    public interface IMatchPreviewInteractor
    {
        Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId);

        MatchPreviewSettingsDto GetSettings(ChampionatDto championat);
    }

    public interface IMatchPreviewRouter
    {
        void Prepare(UIStoryboardSegue segue, int matchId, string title);
    }

    public interface IMatchPreviewView
    {
        void SetSettings(MatchPreviewSettingsDto dto);
        Task SetMatchesAsync(Task<List<MatchPreviewDto>> matches);
        void SetErrorView();
    }
}
