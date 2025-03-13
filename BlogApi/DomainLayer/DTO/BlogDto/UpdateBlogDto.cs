using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.BlogDto
{
    public class UpdateBlogDto
    {
        public string Post { get; set; }
        public string UserId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int CommentId { get; set; }
    }
}
