using System;
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
    }

    public interface ILoginInteractor
    {

    }

    public interface ILoginRouter
    {

    }
    public interface ILoginView
    {
        void SetSettings();
    }
}
