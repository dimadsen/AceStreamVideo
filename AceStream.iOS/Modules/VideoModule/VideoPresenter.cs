using System;
namespace AceStream.Modules.VideoModule
{
    public class VideoPresenter: IVideoPresenter
    {
        public IVideoRouter Router { get; set; }
        public IVideoInteractor Interactor { get; set; }

        public string Link { get; set; }

        private IVideoView _view;

        public VideoPresenter(IVideoView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.PlayLink(Link);
        }
    }
}
