using AceStream.Modules.MatchModule;
using UIKit;

namespace AceStream.Modules.MatchPreviewModule
{
    public class MatchPreviewRouter : IMatchPreviewRouter
    {
        private MatchPreviewViewController _viewController;

        public MatchPreviewRouter(MatchPreviewViewController viewController)
        {
            _viewController = viewController;
        }

        public void Prepare(UIStoryboardSegue segue, int matchId, string title)
        {
            var matchViewController = segue.DestinationViewController as MatchViewController;

            matchViewController.Presenter.MatchId = matchId;
            matchViewController.Presenter.Title = title;
        }
    }
}
