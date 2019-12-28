using System;
using System.Collections.Generic;
using System.Linq;
using AceStream.Dto;

namespace AceStream.Services
{
    public class RegistrationService : IRegistrationService
    {
        List<UserDto> Users;

        public RegistrationService()
        {
            Users = new List<UserDto>
            {
                new UserDto {Id = 1, Name = "Первый", Email = "f@gmail.ru"},
                new UserDto {Id = 2, Name = "Второй", Email = "s@mail.ru"}
            };
        }

        public bool SignUp(RegistrationDto dto)
        {
            var user = Users.FirstOrDefault(x => x.Email == dto.Email);

            if (user == null)
            {
                user = new UserDto { Id = new Random().Next(), Email = dto.Email, Name = dto.Name };
                Users.Add(user);

                return true;
            }

            return false;
        }
    }
    public interface IRegistrationService
    {
        bool SignUp(RegistrationDto dto);
    }
}
