using AceStream.Dto;

namespace AceStream.iOS.Modules.UserModule
{
    public interface IUserConfigurator
    {
        void Configure(IUserView view);
    }

    public interface IUserPresenter
    {
        void ConfigureView();

        void SetUser(int id);
    }

    public interface IUserInteractor
    {
        UserDto GetUser(int id);
    }

    public interface IUserRouter
    {
        
    }

    public interface IUserView
    {
        IUserPresenter Presenter { get; set; }

        void SetSettings();
        void SetUser(UserDto dto);
    }
}
