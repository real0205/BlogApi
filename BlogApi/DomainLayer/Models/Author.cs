using DomainLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.DomainLayer.Models
{
    public class Author : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

    }
}
