using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;
using AceStream.Services;
using AceStream.Services.Interfaces;

namespace AceStream.iOS.Modules.MatchPreviewModule
{
    public class MatchPreviewConfigurator : IMatchPreviewConfigurator
    {
        public void Configure(IMatchPreviewView viewController)
        {
            var presenter = new MatchPreviewPresenter(viewController);
            var interactor = new MatchPreviewInteractor(presenter, Get<IMatchPreviewService>());
            var router = new MatchPreviewRouter(presenter);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
