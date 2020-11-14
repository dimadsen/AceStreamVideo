using AceStream.Dto.SettingsDto;
using AceStream.Services;
using AceStream.Services.Interfaces;

namespace AceStream.Modules.SettingsModule
{
    public class SettingsInteractor: ISettingsInteractor
    {
        private ISettingsPresenter _presenter;
        private ISettingsService _service;

        public SettingsInteractor(ISettingsPresenter presenter)
        {
            _presenter = presenter;
            _service = new SettingsService();
        }

        public string Title => _service.Title;

        public MenuSettingsDto[] GetMenus()
        {
            return _service.GetMenus();
        }
    }
}
