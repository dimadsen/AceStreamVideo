namespace AceStream.iOS.Modules.VideoModule
{
    public interface IVideoConfigurator
    {
        void Configure(IVideoView view);
    }

    public interface IVideoPresenter
    {
        string Link { get; set; }

        void ConfigureView();
    }

    public interface IVideoInteractor
    {
    }

    public interface IVideoRouter
    {
    }

    public interface IVideoView
    {
        IVideoPresenter Presenter { get; set; }

        void PlayLink(string link);
    }
}
