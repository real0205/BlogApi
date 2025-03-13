using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.UserDTO
{
    public class UpdateUserRequest
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        //public string UpdatedAt { get; set; }
        //public string Role { get; set; } = "Reader"; // "Admin", "Author", "Reader"
    }
}
