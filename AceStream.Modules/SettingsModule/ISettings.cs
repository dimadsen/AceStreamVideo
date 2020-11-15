using AceStream.Dto.SettingsDto;

namespace AceStream.iOS.Modules.SettingsModule
{
    public interface ISettingsConfigurator
    {
        void Configure(ISettingsView viewController);
    }

    public interface ISettingsPresenter
    {
        void ConfigureView();
    }

    public interface ISettingsInteractor
    {
        string Title { get; }

        MenuSettingsDto[] GetMenus();
    }

    public interface ISettingsRouter
    {
        //void Prepare(UIStoryboardSegue segue);
        //void Prepare(UINavigationController navigationController, string controllerName);

        //UIViewController InitializeUser();
    }

    public interface ISettingsView
    {
        ISettingsPresenter Presenter { get; set; }
        void SetMenus(MenuSettingsDto[] menus);
        void Set(string title);
    }
}
