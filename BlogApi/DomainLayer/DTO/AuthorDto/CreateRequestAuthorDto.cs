using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.AuthorDto
{
    public class CreateRequestAuthorDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
       
    }
}
