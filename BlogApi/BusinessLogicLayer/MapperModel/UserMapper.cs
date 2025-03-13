using BlogApi.DomainLayer.Models;
using DomainLayer.DTO.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperModel
{
    public class UserMapper
    {
        public User MapUserRequestToUser(CreateRequestUserDto createRequestUserDto)
        {
            return new User
            {
                firstname = createRequestUserDto.firstname,
                lastname = createRequestUserDto.lastname,
            };
        }

        public UserDto MapUserToUserDto(User User)
        {
            return new UserDto
            {
                firstname = User.firstname,
                lastname = User.lastname,
                dob = User.dob,
            };
        }

        public User MapUpdateUserDtoToUser(UpdateUserDto updateUserDto)
        {
            return new User
            {
                firstname = updateUserDto.firstname,
                lastname = updateUserDto.lastname,
                dob = updateUserDto.dob,
            };
        }
    }
}
