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
    public class BlogService : IBlogService
    {
        //BlogRepository _blogRepository;

        private readonly IBlog _blogRepository;
        private IUnitOfWork unitOfWork;

        public BlogService(IBlog blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public BlogService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public Blog? CreateBlog(Blog blog, out string message)
        {
            if (string.IsNullOrWhiteSpace(blog.Post))
            {
                message = "Post cannot be empty";
                return null;
            }

            if (blog.AuthorId <= 0)
            {
                message = "AuthorId cannot be empty";
                return null;
            }

            if (blog.CategoryId <= 0)
            {
                message = "CategoryId cannot be empty";
                return null;
            }

            if (blog.CommentId <= 0)
            {
                message = "CommentId cannot be empty";
                return null;
            }

            message = "Created Successfuly";
            ; return _blogRepository.Create(blog);
        }

        public bool DeleteBlog(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            Blog? blog = _blogRepository.Get(id);

            if (blog == null)
            {
                return false;
            }

            _blogRepository.Delete(blog);
            return true;
        }

        public List<Blog> GetAllBlog()
        {
            return _blogRepository.Get();
        }

        public Blog? GetBlog(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _blogRepository.Get(id);
        }

        public Blog? UpdateBlog(Blog blog, out string message)
        {
            if (string.IsNullOrWhiteSpace(blog.Post))
            {
                message = "Post is required";
                return null;
            }

            if (blog.AuthorId <= 0)
            {
                message = "AuthorId cannot be empty";
                return null;
            }

            if (blog.CategoryId <= 0)
            {
                message = "CategoryId cannot be empty";
                return null;
            }

            if (blog.CommentId <= 0)
            {
                message = "CommentId cannot be empty";
                return null;
            }

            Blog? updatedBlog = _blogRepository.Get(blog.Id);

            if (updatedBlog is null)
            {
                message = "Author not found";
                return null;
            }
            message = "Author Updated Successfully";
            return updatedBlog;
        }
    }
}
