using UIKit;

namespace AceStream.SubModules.LinkSubModule
{
    public class LinkRouter : ILinkRouter
    {
        private LinkViewController _viewController;

        public LinkRouter(LinkViewController viewController)
        {
            _viewController = viewController;
        }

        public void Prepare(UIStoryboardSegue segue, string link)
        {
            var videoViewController = segue.DestinationViewController as VideoViewController;

            videoViewController.Presenter.Link = link;
        }
    }
}
