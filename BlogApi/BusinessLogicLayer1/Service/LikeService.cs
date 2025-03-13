using BusinessLogicLayer.IService;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Models.BlogModels;


namespace BusinessLogicLayer.Service
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Like> GetAllLikes()
        {
            return _unitOfWork.likeRepository.GetAllLikes();
        }

        public List<Like> GetLikeByPostId(int PostId, out string message)
        {
            if (PostId <= 0)
            {
                message = "Invalid PostId";
                return null;
            }

            Post? postData = _unitOfWork.postRepository.GetPostById(PostId);

            if (postData == null)
            {
                message = "Post not found";
                return null;
            }
            message = "fetched successfully";
            return _unitOfWork.likeRepository.GetLikeByPostId(PostId);
        }

        public List<Like> GetLikeByUserId(int UserId, out string message)
        {
            if (UserId <= 0)
            {
                message = "Invalid PostId";
                return null;
            }

            User? userData = _unitOfWork.userRepository.GetUser(UserId);

            if (userData == null)
            {
                message = "User not found";
                return null;
            }
            message = "List of posts liked by user fetched successfully";
            return _unitOfWork.likeRepository.GetLikeByUserId(UserId);

        }

        public Like LikePost(Like like, out string message)
        {
            if (like.UserId <= 0 || like.PostId <= 0)
            {
                message = "Invalid post Id or Reader Id";
                return null;
            }
            User? fetchUser = _unitOfWork.userRepository.GetUser(like.UserId);
            Post? fetchPost = _unitOfWork.postRepository.GetPostById(like.PostId);

            if (fetchUser == null || fetchPost == null)
            {
                message = "User or Post does not exist";
                return null;
            }
            message = "Post Liked successfully";

            Like likedPost = _unitOfWork.likeRepository.LikePost(like);
            return likedPost;

        }

        public bool UnlikePost(Like like, out string message)
        {

            Like LikeData = _unitOfWork.likeRepository.GetPostByUserIdAndPostId(like);

            if (LikeData == null)
            {
                message = "Post or user not found";
                return false;
            }

            _unitOfWork.likeRepository.UnlikePost(LikeData);

            message = "Unliked Successfully";
            return true;
        }

        public Like GetPostByUserIdAndPostId(Like like, out string message)
        {
            if (like.UserId <= 0 || like.PostId <= 0)
            {
                message = "Invalid post Id or Reader Id";
                return null;
            }

            List<Like> LikedPost = _unitOfWork.likeRepository.GetLikeByPostId(like.PostId);

            List<Like> UserLikedPost = _unitOfWork.likeRepository.GetLikeByUserId(like.UserId);

            if (!LikedPost.Any() || !UserLikedPost.Any())
            {
                message = "Post or user not found";
                return null;
            }

            Like LikedPostByUser = _unitOfWork.likeRepository.GetPostByUserIdAndPostId(like);
            message = "fetched Successfully";

            return LikedPostByUser;
        }
    }
}
