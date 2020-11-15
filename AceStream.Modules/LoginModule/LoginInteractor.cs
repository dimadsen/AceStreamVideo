using AceStream.Dto;
using AceStream.Services.Interfaces;

namespace AceStream.iOS.Modules.LoginModule
{
    public class LoginInteractor : ILoginInteractor
    {
        private ILoginPresenter _presenter;
        private IUserService _service;

        public LoginInteractor(ILoginPresenter presenter, IUserService service)
        {
            _presenter = presenter;
            _service = service;
        }

        public UserDto GetUser(LoginDto login)
        {
            return _service.GetUser(login);
        }
    }
}
