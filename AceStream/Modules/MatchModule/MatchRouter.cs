using System;
using UIKit;

namespace AceStream.Modules.MatchModule
{
    public class MatchRouter: IMatchRouter
    {
        private MatchViewController _controller;

        public MatchRouter(MatchViewController controller)
        {
            _controller = controller;
        }

        public void Prepare(UIStoryboardSegue segue, string link)
        {
            var videoViewController = segue.DestinationViewController as VideoViewController;

            videoViewController.Presenter.Link = link;
        }
    }
}
