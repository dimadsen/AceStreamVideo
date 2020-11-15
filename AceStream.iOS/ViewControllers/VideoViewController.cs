using AceStream.iOS.Modules.VideoModule;
using AVFoundation;
using AVKit;
using Foundation;
using System;

namespace AceStream
{
    public partial class VideoViewController : AVPlayerViewController, IVideoView
    {
        public IVideoPresenter Presenter { get; set; }

        public VideoViewController (IntPtr handle) : base (handle)
        {
            var configurator = new VideoConfigurator();
            configurator.Configure(this);
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