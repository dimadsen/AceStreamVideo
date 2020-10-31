using System;
using AceStream.Dto;
using AceStream.Services;

namespace AceStream.Modules.LoginModule
{
    public class LoginInteractor : ILoginInteractor
    {
        private ILoginPresenter _presenter;
        private IUserSerivice _service;

        public LoginInteractor(ILoginPresenter presenter)
        {
            _presenter = presenter;
            //_service = new UserService(new DataBase());
        }

        public UserDto GetUser(LoginDto login)
        {
            return _service.GetUser(login);
        }
    }
}
