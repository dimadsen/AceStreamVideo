using AceStream.iOS.Modules.MatchModule;
using AceStream.Services;
using AceStream.Services.Interfaces;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream.Modules.MatchModule
{
    public class MatchConfigurator : IMatchConfigurator
    {
        public void Configure(IMatchView view)
        {
            var presenter = new MatchPresenter(view);
            var interactor = new MatchInteractor(presenter, Get<IMatchService>());
            var router = new MatchRouter(view);

            view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
