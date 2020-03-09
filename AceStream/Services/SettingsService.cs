using AceStream.Dto.SettingsDto;

namespace AceStream.Services
{
    public class SettingsService : ISettingsService
    {
        public string Title => "Настройки";

        public MenuSettingsDto[] GetMenus()
        {
            var menu = new MenuSettingsDto[]
            {
                new MenuSettingsDto { Name = "Аккаунт", Image = "user-male.png" },
                new MenuSettingsDto { Name = "О приложении", Image = "info-circle-outline.png" }
            };

            return menu;
        }
    }

    public interface ISettingsService
    {
        string Title { get; }

        MenuSettingsDto[] GetMenus();
    }
}
