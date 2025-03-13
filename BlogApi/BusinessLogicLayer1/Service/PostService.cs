using BusinessLogicLayer.IService;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Models.BlogModels;


namespace BusinessLogicLayer.Service
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Post? CreatePost(Post post, out string message)
        {
            
            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Post Title cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Post Content cannot be null";
                return null;
            }

            User? user = _unitOfWork.userRepository.GetUser(post.AuthorId);

            if (user == null)
            {
                message = "Author cannot be found";
                return null;
            }

            //category check

            Post result = _unitOfWork.postRepository.CreatePost(post);
            message = "Successful";
            return result;
        }



        public bool DeletePost(int id, out string message)
        {
            if (id <= 0)
            {
                message = "Invalid";
                return false;
            }

            Post? post = _unitOfWork.postRepository.GetPostById(id);

            if (post == null)
            {
                message = "Post not found";
                return false;
            }

            _unitOfWork.postRepository.DeletePost(post);
            message = "Deleted Successfully";
            return true;

        }

        public List<Post> GetAllPost()
        {
            return _unitOfWork.postRepository.GetAllPost();
        }

        public Post? GetPost(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _unitOfWork.postRepository.GetPostById(id);
        }

        public List<Post> GetPostByAuthorId(int AuthorId, out string message)
        {
            if (AuthorId <= 0)
            {
                message = "Author Id cannot below 1";
                return null;
            }
            // fetch role first to check if role is valid 
            List<Post> result = _unitOfWork.postRepository.GetPostByAuthorId(AuthorId);

            if (result == null)
            {
                message = "Post not found";
                return null;
            }

            message = "Successfully fetched users";
            return result;
        }

        public Post? UpdatePost(Post post, out string message)
        {
            if (post.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Title))
            {
                message = "Post Title cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(post.Content))
            {
                message = "Post Content cannot be null";
                return null;
            }

            Post? updatedPost = _unitOfWork.postRepository.UpdatePost(post);

            if (updatedPost is null)
            {
                message = "User not found";
                return null;
            }

            message = "Successfully Upated user";
            return updatedPost;
        }
    }
}
