using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using DataAccessLayer.Data.IRepositories;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class CategoryService : ICategoryService
    {
        //CategoryRepository _categoryRepository;

        private readonly ICategory _categoryRepository;

        public CategoryService(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public Category? CreateCategory(Category category, out string message)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                message = "Name cannot be empty";
                return null;
            }

            message = "Created Successfuly";
            ; return _categoryRepository.Create(category);
        }

        public bool DeleteCategory(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            Category? category = _categoryRepository.Get(id);

            if (category == null)
            {
                return false;
            }

            _categoryRepository.Delete(category);
            return true;
        }

        public List<Category> GetAllCategory()
        {
            return _categoryRepository.Get();
        }

        public Category? GetCategory(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _categoryRepository.Get(id);
        }

        public Category? UpdateCategory(Category category, out string message)
        {

            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                message = "Name is required";
                return null;
            }

            Category? updatedCategory = _categoryRepository.Get(category.Id);

            if (updatedCategory is null)
            {
                message = "Category not found";
                return null;
            }
            message = "Category Updated Successfully";
            return updatedCategory;
        }
    }
}
