using System;
using AceStream.Dto;

namespace AceStream.Modules.RegistrationModule
{
    public interface IRegistrationConfigurator
    {
        void Configure(RegistrationViewController viewController);
    }
    public interface IRegistrationPresenter
    {
        IRegistrationRouter Router { get; set; }
        IRegistrationInteractor Interactor { get; set; }

        void ConfigureView();
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

    }
}
