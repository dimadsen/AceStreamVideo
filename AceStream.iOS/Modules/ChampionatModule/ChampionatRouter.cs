using UIKit;

namespace AceStream.Modules.ChampionatModule
{
    public class ChampionatRouter : IChampionatRouter
    {
        private ChampionatViewController _viewController;

        public ChampionatRouter(ChampionatViewController viewController)
        {
            _viewController = viewController;
        }

        public void Prepare(UIStoryboardSegue segue, int championatId)
        {
            var matchPreviewViewController = segue.DestinationViewController as MatchPreviewViewController;

            matchPreviewViewController.Presenter.ChampionatId = championatId;
        }

    }
}
