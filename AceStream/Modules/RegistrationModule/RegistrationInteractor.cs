using System;
using AceStream.Dto;
using AceStream.Services;

namespace AceStream.Modules.RegistrationModule
{
    public class RegistrationInteractor: IRegistrationInteractor
    {
        private IRegistrationPresenter _presenter;

        private IRegistrationService _service;

        public RegistrationInteractor(IRegistrationPresenter presenter)
        {
            _presenter = presenter;

            _service = new RegistrationService();
        }

        public bool SignUp(RegistrationDto dto)
        {
            return _service.SignUp(dto);
        }
    }
}
