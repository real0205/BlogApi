using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface ICommentService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Comment? CreateComment(Comment comment, out string message);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool DeleteComment(int id, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Comment> GetAllComment();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Comment? GetCommentById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Comment? UpdateComment(Comment comment, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        bool VerifyUsersCommentOnPost(Comment comment);
        
    }
}
