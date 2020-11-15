using AceStream.Services.Interfaces;
using static AceStream.Infrastructure.DependencyInjection.ServiceCollection;

namespace AceStream.iOS.Modules.RegistrationModule
{
    public class RegistrationConfigurator : IRegistrationConfigurator
    {
        public void Configure(IRegistrationView view)
        {
            var presenter = new RegistrationPresenter(view);
            var interactor = new RegistrationInteractor(presenter, Get<IUserService>());
            var router = new RegistrationRouter(presenter);

            view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
