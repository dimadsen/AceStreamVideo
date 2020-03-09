namespace AceStream.Modules.SettingsModule
{
    public class SettingsPresenter : ISettingsPresenter
    {
        public ISettingsRouter Router { get; set; }
        public ISettingsInteractor Interactor { get; set; }
        private ISettingsView _view;

        public SettingsPresenter(ISettingsView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetMenus(Interactor.GetMenus());
            _view.Set(Interactor.Title);
        }
    }
}
