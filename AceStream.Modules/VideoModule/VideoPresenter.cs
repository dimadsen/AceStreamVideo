namespace AceStream.iOS.Modules.VideoModule
{
    public class VideoPresenter : IVideoPresenter
    {
        public string Link { get; set; }

        private IVideoView _view;

        public void ConfigureView(IVideoView view)
        {
            _view = view;

            _view.PlayLink(Link);
        }
    }
}
