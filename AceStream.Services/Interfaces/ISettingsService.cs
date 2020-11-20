using AceStream.Dto.SettingsDto;

namespace AceStream.Services.Interfaces
{
    public interface ISettingsService
    {
        string Title { get; }

        MenuSettingsDto[] GetMenus();
    }
}
