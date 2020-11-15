namespace AceStream.iOS.Modules.VideoModule
{
    public class VideoConfigurator : IVideoConfigurator
    {

        public void Configure(IVideoView view)
        {
            var presenter = new VideoPresenter(view);

            view.Presenter = presenter;
        }
    }
}
