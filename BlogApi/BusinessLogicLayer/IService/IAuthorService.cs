using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface IAuthorService
    {
        /// <summary>
        /// Get Author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Author? GetAuthor(int id);

        /// <summary>
        /// Get all Author
        /// </summary>
        /// <returns></returns>
        List<Author> GetAllAuthor();

        /// <summary>
        /// Delete Author
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteAuthor(int id);

        /// <summary>
        /// Update Author
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        Author? UpdateAuthor(Author Author, out string message);

        /// <summary>
        /// Create Author
        /// </summary>
        /// <param name="Author"></param>
        /// <returns></returns>
        Author? CreateAuthor(Author Author, out string message);
    }
}
