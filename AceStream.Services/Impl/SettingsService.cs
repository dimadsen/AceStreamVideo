using AceStream.Dto.SettingsDto;
using AceStream.Services.Interfaces;

namespace AceStream.Services
{
    public class SettingsService : ISettingsService
    {
        public string Title => "Настройки";

        public MenuSettingsDto[] GetMenus()
        {
            var menu = new MenuSettingsDto[]
            {
                new MenuSettingsDto { Name = "Аккаунт", Image = "user2.png" },
                new MenuSettingsDto { Name = "О приложении", Image = "About.png" }
            };

            return menu;
        }
    }
}
