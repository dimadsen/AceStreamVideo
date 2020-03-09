using AceStream.Dto;

namespace AceStream.SubModules.UserSubModule
{
    public interface IUserConfigurator
    {
        void Configure(UserViewController viewController);
    }

    public interface IUserPresenter
    {
        IUserRouter Router { get; set; }
        IUserInteractor Interactor { get; set; }

        void ConfigureView();
    }

    public interface IUserInteractor
    {
        UserDto GetUser();
    }

    public interface IUserRouter
    {
        void Prepare();
    }

    public interface IUserView
    {
        void SetSettings(UserDto dto);
    }
}
