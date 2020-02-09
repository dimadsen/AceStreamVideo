namespace AceStream.Modules.VideoModule
{
    public interface IVideoConfigurator
    {
        void Configure(VideoViewController controller);
    }

    public interface IVideoPresenter
    {
        IVideoRouter Router { get; set; }
        IVideoInteractor Interactor { get; set; }
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
        void PlayLink(string link);
    }
}
