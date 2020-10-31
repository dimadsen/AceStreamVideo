using AceStream.Dto;
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

        public void Prepare(UIStoryboardSegue segue, ChampionatDto championat)
        {
            var matchPreviewViewController = segue.DestinationViewController as MatchPreviewViewController;

            matchPreviewViewController.Presenter.Championat = championat;
        }

    }
}
