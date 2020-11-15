using AceStream.Services.Interfaces;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream.iOS.Modules.UserModule
{
    public class UserConfigurator: IUserConfigurator
    {
        public void Configure(IUserView view)
        {
            var presenter = new UserPresenter(view);
            var interactor = new UserInteractor(presenter, Get<IUserService>());
            var router = new UserRouter(presenter);

            view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
