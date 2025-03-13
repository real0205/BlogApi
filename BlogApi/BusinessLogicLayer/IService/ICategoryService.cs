using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Category? GetCategory(int id);

        /// <summary>
        /// Get all Category
        /// </summary>
        /// <returns></returns>
        List<Category> GetAllCategory();

        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCategory(int id);

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category? UpdateCategory(Category category, out string message);

        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        Category? CreateCategory(Category category, out string message);
    }
}
