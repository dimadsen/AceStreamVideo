using AceStream.iOS.Modules.VideoModule;

namespace AceStream.Modules.LinkModule
{
    public class LinkRouter : ILinkRouter
    {
        private ILinkPresenter _presenter;

        public LinkRouter(ILinkPresenter presenter)
        {
            _presenter = presenter;
        }

        public void PrepareForSegue(object destinationView, string link)
        {
            var view = destinationView as IVideoView;

            view.Presenter.Link = link;
        }
    }
}
