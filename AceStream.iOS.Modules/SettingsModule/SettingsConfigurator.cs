using System;
namespace AceStream.iOS.Modules.SettingsModule
{
    public class SettingsConfigurator : ISettingsConfigurator
    {
        public void Configure(ISettingsView view)
        {
            var presenter = new SettingsPresenter(view);
            var interactor = new SettingsInteractor(presenter);
            var router = new SettingsRouter(presenter);

            view.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
