using AceStream.Dto;

namespace AceStream.iOS.Modules.SquardModule
{
    public interface ISquardConfigurator
    {
        void Configure(ISquardView view);
    }

    public interface ISquardPresenter
    {        
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
        ISquardPresenter Presenter { get; set; }

        void SetSettings();
        void SetPlayers(MatchDto match);
        void SetTableSquard();
        void SetNotFoundPlayers();
    }
}
