using System;
namespace AceStream.SubModules.LinkSubModule
{
    public class LinkConfigurator: ILinkConfigurator
    {
        public void Configure(LinkViewController viewController)
        {
            var presenter = new LinkPresenter(viewController);
            var interactor = new LinkInteractor(presenter);
            var router = new LinkRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
