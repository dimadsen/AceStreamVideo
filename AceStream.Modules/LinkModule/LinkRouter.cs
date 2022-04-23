using AceStream.iOS.Modules.VideoModule;

namespace AceStream.Modules.LinkModule
{
    public class LinkRouter : ILinkRouter
    {
        public void PrepareForSegue(object destinationView, string link)
        {
            var view = destinationView as IVideoView;

            view.Presenter.Link = link;
        }
    }
}
