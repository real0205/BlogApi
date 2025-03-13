using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface ICategorieService
    {
        /// <summary>
        ///     Get category object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Category object</returns>
        DomainLayer.Models.BlogModels.Category GetCategory(int id);


        /// <summary>
        ///     Get all category in the database
        /// </summary>
        /// <returns>List of Category Object</returns>
        List<DomainLayer.Models.BlogModels.Category> GetAllCategory();

        /// <summary>
        ///     Remove a Category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteCategory(int id, out string message);


        /// <summary>
        ///     Modify a Category object
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Uodated Object</returns>
        DomainLayer.Models.BlogModels.Category? UpdateCategory(DomainLayer.Models.BlogModels.Category category, out string message);


        /// <summary>
        ///     Create a Category
        /// </summary>
        /// <param name="category"></param>
        /// <returns>Create a new Category object</returns>
        DomainLayer.Models.BlogModels.Category? CreateCategory(DomainLayer.Models.BlogModels.Category category, out string message);
    }
}
