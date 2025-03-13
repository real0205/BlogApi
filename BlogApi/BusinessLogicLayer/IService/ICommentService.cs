using BlogApi.DomainLayer.Models;
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
        /// Get Comment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Comment? GetComment(int id);

        /// <summary>
        /// Get all Comment
        /// </summary>
        /// <returns></returns>
        List<Comment> GetAllComment();

        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteComment(int id);

        /// <summary>
        /// Update Comment
        /// </summary>
        /// <param name="Comment"></param>
        /// <returns></returns>
        Comment? UpdateComment(Comment Comment, out string message);

        /// <summary>
        /// Create Comment
        /// </summary>
        /// <param name="Comment"></param>
        /// <returns></returns>
        Comment? CreateComment(Comment Comment, out string message);
    }
}
