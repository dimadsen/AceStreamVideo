using System;
using AceStream.Dto;
using AceStream.Services;
using AceStream.Services.Interfaces;

namespace AceStream.Modules.RegistrationModule
{
    public class RegistrationInteractor: IRegistrationInteractor
    {
        private IRegistrationPresenter _presenter;

        private IUserSerivice _service;

        public RegistrationInteractor(IRegistrationPresenter presenter)
        {
            _presenter = presenter;
        }

        public bool SignUp(RegistrationDto dto)
        {
            return _service.SignUp(dto);
        }
    }
}
