using System;
namespace AceStream.Modules.VideoModule
{
    public class VideoConfigurator : IVideoConfigurator
    {

        public void Configure(VideoViewController controller)
        {
            var presenter = new VideoPresenter(controller);

            controller.Presenter = presenter;
        }
    }
}
