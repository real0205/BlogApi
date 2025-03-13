using DomainLayer.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.AuthDTO
{
    public class LoginResponse
    {
        public UserDto userData { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
}
