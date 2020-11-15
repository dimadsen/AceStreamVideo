namespace AceStream.iOS.Modules.SquardModule
{
    public class SquardConfigurator : ISquardConfigurator
    {
        public void Configure(ISquardView view)
        {
            var presenter = new SquardPresenter(view);
            var interactor = new SquardInteractor(presenter);
            var router = new SquardRouter(presenter);

            view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
