using System;
using AceStream.Dto;
using AceStream.Services;
using AceStreamDb;

namespace AceStream.Modules.RegistrationModule
{
    public class RegistrationInteractor: IRegistrationInteractor
    {
        private IRegistrationPresenter _presenter;

        private IUserSerivice _service;

        public RegistrationInteractor(IRegistrationPresenter presenter)
        {
            _presenter = presenter;

            _service = new UserService(new DataBase());
        }

        public bool SignUp(RegistrationDto dto)
        {
            return _service.SignUp(dto);
        }
    }
}
