using System;
namespace AceStream.SubModules.SquardSubModule
{
    public class SquardConfigurator : ISquardConfigurator
    {
        public void Configure(SquardViewController viewController)
        {
            var presenter = new SquardPresenter(viewController);
            var interactor = new SquardInteractor(presenter);
            var router = new SquardRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
