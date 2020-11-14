using AceStream.Dto;
using AceStream.iOS.Modules.MatchModule;
using UIKit;

namespace AceStream.Modules.MatchModule
{
    public class MatchRouter : IMatchRouter
    {
        private IMatchView _controller;

        public MatchRouter(IMatchView controller)
        {
            _controller = controller;
        }

        public SegmentedViewController InitializeSegmented(MatchDto match)
        {
            var controller = new SegmentedViewController(match);

            return controller;
        }

        public void Prepare(UIStoryboardSegue segue, string link)
        {
            var videoViewController = segue.DestinationViewController as VideoViewController;

            videoViewController.Presenter.Link = link;
        }
    }
}
