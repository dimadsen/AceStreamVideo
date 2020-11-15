using AceStream.Services.Interfaces;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream.Modules.LinkModule
{
    public class LinkConfigurator : ILinkConfigurator
    {
        public void Configure(ILinkView view)
        {
            var presenter = new LinkPresenter(view);
            var interactor = new LinkInteractor(presenter, Get<ILinkService>());
            var router = new LinkRouter(presenter);

            view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
