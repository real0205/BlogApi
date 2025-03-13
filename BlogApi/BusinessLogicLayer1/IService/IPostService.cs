using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface IPostService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Post? CreatePost(Post post, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AuthorId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        List<Post> GetPostByAuthorId(int AuthorId, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool DeletePost(int id, out string message);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Post> GetAllPost();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Post? GetPost(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Post? UpdatePost(Post post, out string message);
    }
}
