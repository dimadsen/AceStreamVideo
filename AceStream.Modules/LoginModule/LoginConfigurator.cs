using AceStream.Services.Interfaces;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream.iOS.Modules.LoginModule
{
    public class LoginConfigurator : ILoginConfigurator
    {
        public void ConfigureView(ILoginView _view)
        {
            var presenter = new LoginPresenter(_view);
            var interactor = new LoginInteractor(presenter, Get<IUserService>());
            var router = new LoginRouter(presenter);

            _view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
