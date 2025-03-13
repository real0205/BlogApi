using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositries
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LikeRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Like LikePost(Like like)
        {
            _applicationDbContext.Likes.Add(like);
            _applicationDbContext.SaveChanges();
            return like;

        }

        public void UnlikePost(Like like)
        {
            _applicationDbContext.Remove(like);
            _applicationDbContext.SaveChanges();
        }

        public List<Like> GetLikeByPostId(int PostId)
        {
            List<Like> LikedPostByPostId = _applicationDbContext.Likes.Where(val => val.PostId == PostId).ToList();
            return LikedPostByPostId;
        }

        public List<Like> GetLikeByUserId(int UserId)
        {
            List<Like> LikedPostUserId = _applicationDbContext.Likes.Where(val => val.UserId == UserId).ToList();
            return LikedPostUserId;
        }

        public List<Like> GetAllLikes()
        {
            List<Like> AllLikedPost = _applicationDbContext.Likes.ToList();
            return AllLikedPost;
        }

        public Like GetPostByUserIdAndPostId(Like like)
        {
            Like? LikedPostByUser = _applicationDbContext.Likes
                .Where(u => u.PostId == like.PostId && u.UserId == like.UserId)
                .FirstOrDefault();

            return LikedPostByUser;
        }
    }
}
