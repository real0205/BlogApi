using DataAccessLayer.Data;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICommentRepository
    {
        /// <summary>
        /// Create a comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment Create(Comment comment);

        /// <summary>
        /// Delete comment
        /// </summary>
        /// <param name="comment"></param>
        void Delete(Comment comment);

        /// <summary>
        /// Get comment by comment id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Comment? Get(int id);
        /// <summary>
        /// Get All comments 
        /// </summary>
        /// <returns></returns>
        List<Comment> Get();

        /// <summary>
        /// Edit comment
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        Comment? Update(Comment comment);
    }
}
