using System;
using AceStream.Dto;

namespace AceStream.Modules.LoginModule
{
    public interface ILoginConfigurator
    {
        void ConfigureView(LoginViewController viewController);
    }

    public interface ILoginPresenter
    {
        ILoginRouter Router { get; set; }
        ILoginInteractor Interactor { get; set; }

        void ConfigureView();

        void SignOut();
    }

    public interface ILoginInteractor
    {
        UserDto GetUser(LoginDto login);
    }

    public interface ILoginRouter
    {

    }
    public interface ILoginView
    {
        void SetSettings();
    }
}
