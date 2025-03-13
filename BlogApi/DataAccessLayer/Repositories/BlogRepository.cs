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
    public class BlogRepository : IBlog
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public BlogRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Blog Create(Blog blog)
        {
            _applicationDbContext.Blogs.Add(blog);
            _applicationDbContext.SaveChanges();

            return blog;
        }

        public void Delete(Blog blog)
        {
            _applicationDbContext.Remove(blog);
            _applicationDbContext.SaveChanges();
        }

        public Blog? Get(int id)
        {
            Blog? blog = _applicationDbContext.Blogs.Find(id);
            return blog;
        }

        public List<Blog> Get()
        {
            return _applicationDbContext.Blogs.ToList();
        }

        public Blog Update(int id, Blog blog)
        {
            Blog existingBlog = _applicationDbContext.Blogs.Find(id);

            if (existingBlog == null)
            {
                return null;
            }

            existingBlog.Post = blog.Post;

            _applicationDbContext.Blogs.Update(existingBlog);
            _applicationDbContext.SaveChanges();

            existingBlog.AuthorId = blog.AuthorId;

            _applicationDbContext.Blogs.Update(existingBlog);
            _applicationDbContext.SaveChanges();

            existingBlog.AuthorId = blog.CategoryId;

            _applicationDbContext.Blogs.Update(existingBlog);
            _applicationDbContext.SaveChanges();

            existingBlog.CommentId = blog.CommentId;

            _applicationDbContext.Blogs.Update(existingBlog);
            _applicationDbContext.SaveChanges();

            existingBlog.UserId = blog.UserId;

            _applicationDbContext.Blogs.Update(existingBlog);
            _applicationDbContext.SaveChanges();

            return blog;
        }
    }
}
