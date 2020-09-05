namespace AceStream.Modules.ChampionatModule
{
    public class ChampionatConfigurator : IChampionatConfigurator
    {
        public void Configure(ChampionatViewController viewController)
        {
            var presenter = new ChampionatPresenter(viewController);
            var interactor = new ChampionatInteractor(presenter);
            var router = new ChampionatRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
