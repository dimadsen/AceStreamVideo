using System;
namespace AceStream.Modules.SettingsModule
{
    public class SettingsConfigurator : ISettingsConfigurator
    {
        public void Configure(SettingsViewController viewController)
        {
            var presenter = new SettingsPresenter(viewController);
            var interactor = new SettingsInteractor(presenter);
            var router = new SettingsRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
