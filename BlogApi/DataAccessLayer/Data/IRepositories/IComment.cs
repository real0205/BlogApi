using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.IRepositories
{
    public interface IComment
    {
        /// <summary>
        /// Get Comment By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Comment? Get(int id);

        /// <summary>
        /// Get all Comment
        /// </summary>
        /// <returns></returns>
        List<Comment> Get();

        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="Comment"></param>
        void Delete(Comment Comment);

        /// <summary>
        /// Create Comment
        /// </summary>
        /// <param name="Comment"></param>
        /// <returns></returns>
        Comment Create(Comment Comment);

        /// <summary>
        /// Update Comment
        /// </summary>
        /// <param name="Comment"></param>
        /// <returns></returns>
        Comment Update(int id, Comment Comment);
    }
}
