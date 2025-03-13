using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.UnitOfWorkServicesFolder;
using DomainLayer.DTO;
using DomainLayer.DTO.UserDTO;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : Controller
    {
        IUnitOfWorkService _unitOfWork;
        UserMapper _userMapper;

        public UserController(IUnitOfWorkService unitOfWork, UserMapper userMapper)
        {
            _userMapper = userMapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllUsers()
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            return Ok(_unitOfWork.userService.GetAllUsers());
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            User? user = _unitOfWork.userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }


            UserDto UserDto = _userMapper.MapUserToUserDto(user);

            return Ok(UserDto);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetByRole(string role)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            List<User> user = _unitOfWork.userService.GetUserByRole(role, out string message);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest user)
        {
            User mappedUser = _userMapper.MapCreateUserRequestToUser(user);


            User? createdUser = _unitOfWork.userService.CreateUser(mappedUser, out string message);

            if (createdUser == null)
            {
                return BadRequest(message);
            }

            UserDto CreatedCategoryDto = _userMapper.MapUserToUserDto(createdUser);
            return Ok(CreatedCategoryDto);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest user)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            User mappedUser = _userMapper.MapUpdateUserRequestToUser(user);

            User? UserUpdated = _unitOfWork.userService.UpdateUser(mappedUser, out string message);

            if (UserUpdated is null)
            {
                return BadRequest(message);
            }

            UserDto UpdatedUserDto = _userMapper.MapUserToUserDto(UserUpdated);

            return Ok(UpdatedUserDto);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteUser([FromBody] DeleteUserRequest user)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            User mappedUser = _userMapper.MapDeleteUserRequestToCategory(user);

            bool UserDeleted = _unitOfWork.userService.DeleteUser(mappedUser.Id, out string message);

            return Ok(UserDeleted);

        }
    }
}

