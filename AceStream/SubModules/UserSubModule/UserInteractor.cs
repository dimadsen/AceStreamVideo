using AceStream.Dto;
using AceStream.Services;

namespace AceStream.SubModules.UserSubModule
{
    public class UserInteractor: IUserInteractor
    {
        private IUserPresenter _presenter;

        private IUserSerivice service;

        public UserInteractor(IUserPresenter presenter)
        {
            _presenter = presenter;

            service = new UserService();
        }

        public UserDto GetUser()
        {
            return service.GetUser((int)User.Id);
        }
    }
}
