using AceStream.Services;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream.Modules.ChampionatModule
{
    public class ChampionatConfigurator : IChampionatConfigurator
    {
        public void Configure(ChampionatViewController viewController)
        {
            var presenter = new ChampionatPresenter(viewController);
            var router = new ChampionatRouter(viewController);

            var interactor = new ChampionatInteractor(presenter, Get<IChampionatService>());

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
