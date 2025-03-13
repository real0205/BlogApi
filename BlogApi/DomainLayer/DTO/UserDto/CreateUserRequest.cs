using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.UserDTO
{
    public class CreateUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; } = "Reader"; // "Admin", "Author", "Reader"
        public string Password { get; set; }
    }
}
