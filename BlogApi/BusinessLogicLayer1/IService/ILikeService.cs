using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface ILikeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <returns></returns>
        Like LikePost(Like like, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        bool UnlikePost(Like like, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        List<Like> GetLikeByPostId(int PostId, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PostId"></param>
        /// <returns></returns>
        List<Like> GetLikeByUserId(int UserId, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<Like> GetAllLikes();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="like"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Like GetPostByUserIdAndPostId(Like like, out string message);
    }
}
