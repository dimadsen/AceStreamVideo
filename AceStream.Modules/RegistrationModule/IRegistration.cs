using System;
using AceStream.Dto;

namespace AceStream.iOS.Modules.RegistrationModule
{
    public interface IRegistrationConfigurator
    {
        void Configure(IRegistrationView view);
    }
    public interface IRegistrationPresenter
    {

        void ConfigureView();
        bool SignUp(RegistrationDto dto);
    }

    public interface IRegistrationInteractor
    {

        bool SignUp(RegistrationDto dto);
    }

    public interface IRegistrationRouter
    {

    }

    public interface IRegistrationView
    {
        IRegistrationPresenter Presenter { get; set; }
        void SetSettings();
    }
}
