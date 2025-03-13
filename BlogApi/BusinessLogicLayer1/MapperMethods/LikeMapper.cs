using DomainLayer.DTO.LikeDTO;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperMethods
{
    public class LikeMapper
    {
        public Like MapLikeDtoToLike(LikeDto likeDto)
        {
            return new Like()
            {
                UserId = likeDto.UserId,
                PostId = likeDto.PostId,
            };
        }

        public LikeDto MapLikeToLikeDto(Like like)
        {
            return new LikeDto()
            {
                UserId = like.UserId,
                PostId = like.PostId,
            };
        }
    }
}
