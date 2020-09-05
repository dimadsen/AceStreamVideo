using System;
namespace AceStream.Modules.RegistrationModule
{
    public class RegistrationConfigurator : IRegistrationConfigurator
    {
        public void Configure(RegistrationViewController viewController)
        {
            var presenter = new RegistrationPresenter(viewController);
            var interactor = new RegistrationInteractor(presenter);
            var router = new RegistrationRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
