using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;
using AceStream.Services.Interfaces;

namespace AceStream.iOS.Modules.MatchPreviewModule
{
    public class MatchPreviewConfigurator : IMatchPreviewConfigurator
    {
        public void Configure(IMatchPreviewView view)
        {
            var presenter = new MatchPreviewPresenter(view);
            var interactor = new MatchPreviewInteractor(presenter, Get<IMatchPreviewService>());
            var router = new MatchPreviewRouter(presenter);

            view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
