namespace AceStream.iOS.Modules.VideoModule
{
    public interface IVideoPresenter
    {
        string Link { get; set; }

        void ConfigureView(IVideoView view);
    }

    public interface IVideoView
    {
        IVideoPresenter Presenter { get; set; }

        void PlayLink(string link);
    }
}
