using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get product Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category Object by Id</returns>
       Category? Get(int id);



        /// <summary>
        /// List of Category
        /// </summary>
        /// <returns>List of Category</returns>
        List<Category> Get();



        /// <summary>
        /// Delete Category
        /// </summary>
        /// <param name="category"></param>
        void Delete(Category category);


        /// <summary>
        /// Create Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Category Object</returns>
        Category Create(Category category);

        /// <summary>
        /// Update Category Details
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Updated Object</returns>
        Category? Update(Category category);
    }
}
