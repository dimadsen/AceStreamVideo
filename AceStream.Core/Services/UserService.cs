using System;
using AceStream.Dto;

namespace AceStream.Services
{
    public class UserService : IUserSerivice
    {
        public UserDto GetUser()
        {
            return new UserDto
            {
                Avatar = "avatar",
                Nickname = "Kelment"
            };
        }
    }

    public interface IUserSerivice
    {
        UserDto GetUser();
    }
}
