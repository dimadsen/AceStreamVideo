using AceStream.Dto;

namespace AceStream.Services.Interfaces
{
    public interface IUserService
    {
        UserDto GetUser(int id);
        UserDto GetUser(LoginDto login);
        bool SignUp(RegistrationDto login);
    }
}
