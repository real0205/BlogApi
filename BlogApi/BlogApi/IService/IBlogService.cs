using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface IBlogService
    {
        /// <summary>
        /// Get Blog by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Blog? GetBlog(int id);

        /// <summary>
        /// Get all Blog
        /// </summary>
        /// <returns></returns>
        List<Blog> GetAllBlog();

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteBlog(int id);

        /// <summary>
        /// Update Blog
        /// </summary>
        /// <param name="Blog"></param>
        /// <returns></returns>
        Blog? UpdateBlog(Blog Blog, out string message);

        /// <summary>
        /// Create Blog
        /// </summary>
        /// <param name="Blog"></param>
        /// <returns></returns>
        Blog? CreateBlog(Blog Blog, out string message);
    }
}
