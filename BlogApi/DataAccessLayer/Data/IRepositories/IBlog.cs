using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.IRepositories
{
    public interface IBlog
    {
        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Blog? Get(int id);

        /// <summary>
        /// Get all Blog
        /// </summary>
        /// <returns></returns>
        List<Blog> Get();

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="Blog"></param>
        void Delete(Blog Blog);

        /// <summary>
        /// Create Blog
        /// </summary>
        /// <param name="Blog"></param>
        /// <returns></returns>
        Blog Create(Blog Blog);

        /// <summary>
        /// Update Blog
        /// </summary>
        /// <param name="Blog"></param>
        /// <returns></returns>
        Blog Update(int id, Blog Blog);
    }
}
