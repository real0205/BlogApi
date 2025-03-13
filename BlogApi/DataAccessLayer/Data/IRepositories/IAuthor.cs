using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.IRepositories
{
    public interface IAuthor
    {
        /// <summary>
        /// Get Author By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Author? Get(int id);

        /// <summary>
        /// Get all Author
        /// </summary>
        /// <returns></returns>
        List<Author> Get();

        /// <summary>
        /// Delete Author
        /// </summary>
        /// <param name="Author"></param>
        void Delete(Author Author);

        /// <summary>
        /// Create Author
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        Author Create(Author Author);

        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        Author Update(int id, Author Author);
    }
}
