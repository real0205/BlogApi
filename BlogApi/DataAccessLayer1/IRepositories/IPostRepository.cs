using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IPostRepository
    {
        /// <summary>
        /// Get Post by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user Object by Id</returns>
        Post? GetPostById(int id);


        /// <summary>
        /// Get Post by AuthorId
        /// </summary>
        /// <param name="AuthorId"></param>
        /// <returns>user Object by Id</returns>
        List<Post> GetPostByAuthorId(int AuthorId);


        /// <summary>
        /// All Post
        /// </summary>
        /// <returns>List of users</returns>
        List<Post> GetAllPost();



        /// <summary>
        /// Delete Post
        /// </summary>
        /// <param name="post"></param>
        void DeletePost(Post post);


        /// <summary>
        /// Create Post
        /// </summary>
        /// <param name="post"></param>
        /// <returns>User Object</returns>
        Post CreatePost(Post post);

        /// <summary>
        /// Update Post Details
        /// </summary>
        /// <param name="post"></param>
        /// <returns>Updated Object</returns>
        Post? UpdatePost(Post post);
    }
}
