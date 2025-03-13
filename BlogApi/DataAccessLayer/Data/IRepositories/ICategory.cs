using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.IRepositories
{
    public interface ICategory
    {
        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Category? Get(int id);

        /// <summary>
        /// Get all Category
        /// </summary>
        /// <returns></returns>
        List<Category> Get();

        /// <summary>
        /// Delete category
        /// </summary>
        /// <param name="category"></param>
        void Delete(Category category);

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category Create(Category category);

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category Update(int id, Category category);
    }
}
