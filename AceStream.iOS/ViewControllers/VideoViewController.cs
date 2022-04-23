using AceStream.iOS.Modules.VideoModule;
using AVFoundation;
using AVKit;
using Foundation;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace AceStream
{
    public partial class VideoViewController : AVPlayerViewController, IVideoView
    {
        public IVideoPresenter Presenter { get; set; }

        public VideoViewController (IntPtr handle) : base (handle)
        {
            Presenter = ServiceProviderFactory.ServiceProvider.GetService<IVideoPresenter>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Presenter.ConfigureView(this);
        }

        public void PlayLink(string link)
        {
            Player = new AVPlayer(new NSUrl(link));

            Player.Play();
        }

    }
}