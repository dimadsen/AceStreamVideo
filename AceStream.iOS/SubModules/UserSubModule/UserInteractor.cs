using AceStream.Dto;
using AceStream.Services.Interfaces;

namespace AceStream.SubModules.UserSubModule
{
    public class UserInteractor: IUserInteractor
    {
        private IUserPresenter _presenter;

        private IUserSerivice service;

        public UserInteractor(IUserPresenter presenter)
        {
            _presenter = presenter;            
        }

        public UserDto GetUser()
        {
            return service.GetUser((int)User.Id);
        }
    }
}
