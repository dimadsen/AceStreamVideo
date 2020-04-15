using System;
using AceStream.Dto;

namespace AceStream.Services
{
    public class LoginService : ILoginService
    {
        public UserDto GetUser(LoginDto login)
        {
            if (login.Email == "first@mail.ru")
                return new UserDto { Id = 1 };
            if (login.Email == "second@mail.ru")
                return new UserDto { Id = 2 };
            if (login.Email == "wi@mail.ru")
                return new UserDto { Id = 3 };
            else
                return null;
        }
    }
    public interface ILoginService
    {
        UserDto GetUser(LoginDto login);
    }
}
