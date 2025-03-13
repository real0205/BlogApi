using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.PostDTO
{
    public class UpdatePostRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        //public int AuthorId { get; set; } we should not be updating AuthorId
        public int CategoryId { get; set; }
    }
}
