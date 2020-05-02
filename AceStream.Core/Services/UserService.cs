using System;
using AceStream.Dto;
using AceStreamDb;

namespace AceStream.Services
{
    public class UserService : IUserSerivice
    {
        private DataBase _db;

        public UserService()
        {
            _db = new DataBase();
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
