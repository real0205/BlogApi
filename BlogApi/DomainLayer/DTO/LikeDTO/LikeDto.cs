using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO.LikeDTO
{
    public class LikeDto
    {
        public int UserId { get; set; }

        public int PostId { get; set; }
    }
}
