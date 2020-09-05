using AceStream.Dto;
using AceStream.Services.Repositories;

namespace AceStream.Services
{
    public class UserService : IUserSerivice
    {
        private IDataBase _db;

        public UserService(IDataBase db)
        {
            _db = db;
        }

        public UserDto GetUser(int id)
        {
            var user = _db.GetUser(id);

            var dto = new UserDto
            {
                Id = user.Id,
                Avatar = user.Avatar,
                Email = user.Email,
                Nickname = user.Name
            };

            return dto;
        }

        public UserDto GetUser(LoginDto login)
        {
            var user = _db.GetUser(login.Email, login.Password);

            if (user == null)
                return null;

            var dto = new UserDto
            {
                Id = user.Id,
                Avatar = user.Avatar,
                Email = user.Email,
                Nickname = user.Name
            };

            return dto;
        }

        public bool SignUp(RegistrationDto login)
        {
            return _db.SaveUser(login.Name, login.Email, login.Password);
        }
    }

    public interface IUserSerivice
    {
        UserDto GetUser(int id);
        UserDto GetUser(LoginDto login);
        bool SignUp(RegistrationDto login);
    }
}
