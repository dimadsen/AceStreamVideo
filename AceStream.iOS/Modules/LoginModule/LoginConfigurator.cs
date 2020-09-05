using System;
namespace AceStream.Modules.LoginModule
{
    public class LoginConfigurator : ILoginConfigurator
    {
        public void ConfigureView(LoginViewController viewController)
        {
            var presenter = new LoginPresenter(viewController);
            var interactor = new LoginInteractor(presenter);
            var router = new LoginRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
