using DomainLayer.DTO;
using DomainLayer.DTO.UserDTO;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperMethods
{
    public class UserMapper
    {
        public User MapCreateUserRequestToUser(CreateUserRequest CreateUserDto)
        {
            return new User
            {
                Username = CreateUserDto.Username,
                Email = CreateUserDto.Email,
                Role = CreateUserDto.Role,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                Password = CreateUserDto.Password
            };
        }
        public User MapUpdateUserRequestToUser(UpdateUserRequest updateRequestUserDto)
        {
            return new User
            {
                Id = updateRequestUserDto.Id,
                Username = updateRequestUserDto.Username,
                Email = updateRequestUserDto.Email,
                UpdateAt = DateTime.Now
            };
        }

        public UserDto MapUserToUserDto(User user)
        {
            return new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                CreateAt = user.CreateAt,
            };
        }
        public User MapDeleteUserRequestToCategory(DeleteUserRequest deleteRequestUserDto)
        {
            return new User
            {
                Id = deleteRequestUserDto.Id
            };
        }
    }
}
