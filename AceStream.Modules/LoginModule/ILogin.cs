using System;
using AceStream.Dto;

namespace AceStream.iOS.Modules.LoginModule
{
    public interface ILoginConfigurator
    {
        void ConfigureView(ILoginView viewController);
    }

    public interface ILoginPresenter
    {
        void ConfigureView();

        UserDto GetUser(LoginDto login);
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
        ILoginPresenter Presenter { get; set; }
        void SetSettings();
    }
}
