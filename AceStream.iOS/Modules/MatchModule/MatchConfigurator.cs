using AceStream.Services;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream.Modules.MatchModule
{
    public class MatchConfigurator : IMatchConfigurator
    {
        public void Configure(MatchViewController viewController)
        {
            var presenter = new MatchPresenter(viewController);
            var interactor = new MatchInteractor(presenter, Get<IMatchService>());
            var router = new MatchRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
