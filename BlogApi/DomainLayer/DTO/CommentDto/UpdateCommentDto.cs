using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.CommentDTO
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }

        public int UserId { get; set; }
    }
}
