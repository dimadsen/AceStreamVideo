using AceStream.Dto.SettingsDto;
using UIKit;

namespace AceStream.Modules.SettingsModule
{
    public interface ISettingsConfigurator
    {
        void Configure(SettingsViewController viewController);
    }

    public interface ISettingsPresenter
    {
        ISettingsRouter Router { get; set; }
        ISettingsInteractor Interactor { get; set; }

        void ConfigureView();
    }

    public interface ISettingsInteractor
    {
        string Title { get; }

        MenuSettingsDto[] GetMenus();
    }

    public interface ISettingsRouter
    {
        void Prepare(UIStoryboardSegue segue);
        void Prepare(UINavigationController navigationController, string controllerName);
    }

    public interface ISettingsView
    {
        void SetMenus(MenuSettingsDto[] menus);
        void Set(string title);
    }
}
