using System;
using AceStream.Dto;
using AceStream.Services.Interfaces;

namespace AceStream.Services
{
    public class UserService : IUserService
    {
        public UserDto GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto GetUser(LoginDto login)
        {
            throw new NotImplementedException();
        }

        public bool SignUp(RegistrationDto login)
        {
            throw new NotImplementedException();
        }
    }
}
