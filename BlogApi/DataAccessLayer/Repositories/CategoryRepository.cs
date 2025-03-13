using BlogApi.DataAccessLayer.Data;
using BlogApi.DomainLayer.Models;
using DataAccessLayer.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public CategoryRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Category Create(Category category)
        {
            _applicationDbContext.Categories.Add(category);
            _applicationDbContext.SaveChanges();

            return category;
        }

        public void Delete(Category category)
        {
            _applicationDbContext.Remove(category);
            _applicationDbContext.SaveChanges();
        }

        public Category? Get(int id)
        {
            Category? category = _applicationDbContext.Categories.Find(id);
            return category;
        }

        public List<Category> Get()
        {
            return _applicationDbContext.Categories.ToList();
        }

        public Category Update(int id, Category category)
        {
            Category existingCategory = _applicationDbContext.Categories.Find(id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.CategoryName = category.CategoryName;

            _applicationDbContext.Categories.Update(existingCategory);
            _applicationDbContext.SaveChanges();

            return category;
        }
    }
}
