using AceStream.Services;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream.iOS.Modules.ChampionatModule
{
    public class ChampionatConfigurator : IChampionatConfigurator
    {
        public void Configure(IChampionatView view)
        {
            var presenter = new ChampionatPresenter(view);
            var router = new ChampionatRouter(presenter);

            var interactor = new ChampionatInteractor(presenter, Get<IChampionatService>());

            view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
