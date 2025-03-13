using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ILikeRepository
    {
        /// <summary>
        /// Like a post
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like LikePost(Like like);

        /// <summary>
        /// Unlike post
        /// </summary>
        /// <param name="like"></param>
        void UnlikePost(Like like);

        /// <summary>
        /// Gets likes for a post
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        List<Like> GetLikeByPostId(int PostId);

        /// <summary>
        /// Get likes by user id
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        List<Like> GetLikeByUserId(int PostId);

        /// <summary>
        /// Get all likes 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Like> GetAllLikes();

        /// <summary>
        /// Get likes by postiud and userId
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like GetPostByUserIdAndPostId(Like like);
    }
}
