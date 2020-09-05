namespace AceStream.Modules.MatchPreviewModule
{
    public class MatchPreviewConfigurator : IMatchPreviewConfigurator
    {
        public void Configure(MatchPreviewViewController viewController)
        {
            var presenter = new MatchPreviewPresenter(viewController);
            var interactor = new MatchPreviewInteractor(presenter);
            var router = new MatchPreviewRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
