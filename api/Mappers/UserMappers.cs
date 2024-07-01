using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Model;

namespace api.Mappers
{
    public static class UserMappers
    {

        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Email = userModel.Email,
                Name = userModel.Email,
                Mobile = userModel.Mobile
            };
        }

        public static User ToUserFromCreateDTO(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Email = userDto.Email,
                Name = userDto.Name,
                Mobile = userDto.Mobile
            };
        }

    }
}