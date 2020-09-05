using AceStream.Dto;

namespace AceStream.SubModules.SquardSubModule
{
    public interface ISquardConfigurator
    {
        void Configure(SquardViewController viewController);
    }

    public interface ISquardPresenter
    {
        ISquardRouter Router { get; set; }
        ISquardInteractor Interactor { get; set; }

        MatchDto Match { get; set; }

        void ConfigureView();
        void SetPlayers();
        void SetTitleHeader();
        void SetNotFoundPlayers();
    }

    public interface ISquardInteractor
    {
        MatchDto GetMatch(MatchDto match);
    }

    public interface ISquardRouter
    {   
    }

    public interface ISquardView
    {
        void SetSettings();
        void SetPlayers(MatchDto match);
        void SetTableSquard();
        void SetNotFoundPlayers();
    }
}
