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
    }

    public interface ISquardInteractor
    {
    }

    public interface ISquardRouter
    {   
    }

    public interface ISquardView
    {
        void SetTableSquard();
        void SetSettings();
        void SetPlayers(MatchDto match);
    }
}
