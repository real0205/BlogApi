using AutoMapper;
using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperModel;
using DomainLayer.DTO.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            //return Ok(_userService.GetAllUser());

            return Ok(_mapper.Map<IList<UserDto>>(_userService.GetAllUser()));
        }

        [HttpGet]
        public IActionResult GetById(string id)
        {
            User? user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            //UserMapper userMapper = new UserMapper();
            //UserDto userDto = userMapper.MapUserToUserDto(user);

            //return Ok(user);

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] CreateRequestUserDto user)
        {
            UserMapper userMapper = new UserMapper();
            User mappedUser = userMapper.MapUserRequestToUser(user);

            User? createdUser = _userService.CreateUser(mappedUser, out string message);
            if (createdUser == null)
            {
                return BadRequest(message);
            }

            UserDto userDto = userMapper.MapUserToUserDto(createdUser);
            return Ok(createdUser);
        }

        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UpdateUserDto user)
        {
            UserMapper userMapper = new UserMapper();
            User resultOfmapping = userMapper.MapUpdateUserDtoToUser(user);

            User? userUpdated = _userService.UpdateUser(resultOfmapping, out string message);



            if (userUpdated == null)
            {
                return BadRequest(message);
            }

            UserDto userDto = userMapper.MapUserToUserDto(userUpdated);

            return Ok(userDto);
        }
    }
}
