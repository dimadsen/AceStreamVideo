using AceStream.Modules.VideoModule;
using AVFoundation;
using AVKit;
using Foundation;
using System;

namespace AceStream
{
    public partial class VideoViewController : AVPlayerViewController, IVideoView
    {
        public IVideoPresenter Presenter { get; set; }
        public IVideoConfigurator Configurator { get; set; }

        public VideoViewController (IntPtr handle) : base (handle)
        {
            Configurator = new VideoConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Presenter.ConfigureView();
        }

        public void PlayLink(string link)
        {
            Player = new AVPlayer(new NSUrl(link));

            Player.Play();
        }

    }
}