namespace AceStream.Modules.MatchPreviewModule
{
    public class MatchPreviewRouter : IMatchPreviewRouter
    {
        private MatchPreviewViewController _viewController;

        public MatchPreviewRouter(MatchPreviewViewController viewController)
        {
            _viewController = viewController;
        }
    }
}
