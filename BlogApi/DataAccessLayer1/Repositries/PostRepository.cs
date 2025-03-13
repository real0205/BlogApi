using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositries
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PostRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Post CreatePost(Post post)
        {
            _applicationDbContext.Posts.Add(post);
            _applicationDbContext.SaveChanges();
            return post;
        }

        public void DeletePost(Post post)
        {
            _applicationDbContext.Remove(post);
            _applicationDbContext.SaveChanges();
        }

        public List<Post> GetAllPost()
        {
            return _applicationDbContext.Posts.ToList();
        }

        public List<Post> GetPostByAuthorId(int AuthorId)
        {
            List<Post> post = _applicationDbContext.Posts.Where(id => id.AuthorId == AuthorId).ToList();
            return post;
        }

        public Post? GetPostById(int id)
        {
            Post? post = _applicationDbContext.Posts.Find(id);
            return post;
        }

        public Post? UpdatePost(Post post)
        {
            Post? existingPost = _applicationDbContext.Posts.Find(post.Id);

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;
            existingPost.UpdatedAt = post.UpdatedAt;
            existingPost.CategoryId = post.CategoryId;

            _applicationDbContext.Posts.Update(existingPost);
            _applicationDbContext.SaveChanges();

            return existingPost;
        }
    }
}
