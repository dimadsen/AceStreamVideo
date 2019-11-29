using AceStream.Dto;

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
        int ChampionatId { get; set; }

        void ConfigureView();
    }

    public interface IMatchPreviewInteractor
    {
        MatchPreviewDto[] GetMatches(int championatId);
    }

    public interface IMatchPreviewRouter
    {

    }

    public interface IMatchPreviewView
    {
        void SetSettings();
        void SetMatches(MatchPreviewDto[] matches);
    }
}
