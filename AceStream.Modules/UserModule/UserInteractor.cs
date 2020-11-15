using AceStream.Dto;
using AceStream.Services.Interfaces;

namespace AceStream.iOS.Modules.UserModule
{
    public class UserInteractor: IUserInteractor
    {
        private IUserPresenter _presenter;

        private IUserService _service;

        public UserInteractor(IUserPresenter presenter, IUserService service)
        {
            _presenter = presenter;
            _service = service;
        }

        public UserDto GetUser(int id)
        {
            return _service.GetUser(id);
        }
    }
}
