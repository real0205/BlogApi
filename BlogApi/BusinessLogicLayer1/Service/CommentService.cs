using BusinessLogicLayer.IService;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Models.BlogModels;

namespace BusinessLogicLayer.Service
{
    public class CommentService: ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Comment? CreateComment(Comment comment, out string message)
        {
            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                message = "Comment cannot be empty";
                return null;
            }
            bool isUserIdPostIdValid = VerifyUsersCommentOnPost(comment);

            if(isUserIdPostIdValid == false)
            {
                message = "User or post does not exist";
                return null;
            }

            Comment result = _unitOfWork.commentRepository.Create(comment);

            message = "Successful";
            return result;
        }


        public bool DeleteComment(int id, out string message)
        {
            Comment? Result = GetCommentById(id);

            if (Result == null)
            {
                message = "Invalid id";
                return false;
            }

            _unitOfWork.commentRepository.Delete(Result);
            message = "Deleted Successfully";
            return true;
        }

        public List<Comment> GetAllComment()
        {
            return _unitOfWork.commentRepository.Get();
        }

        public Comment? GetCommentById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _unitOfWork.commentRepository.Get(id);
        }

        public Comment? UpdateComment(Comment comment, out string message)
        {
            if (comment.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(comment.Content))
            {
                message = "Comment cannot be empty";
                return null;
            }

            bool isUserIdPostIdValid = VerifyUsersCommentOnPost(comment);

            if (isUserIdPostIdValid == false)
            {
                message = "User or post does not exist";
                return null;
            }

            Comment? updatedComment = _unitOfWork.commentRepository.Update(comment);

            if (updatedComment is null)
            {
                message = "comment not found";
                return null;
            }

            message = "Successfully Upated";
            return updatedComment;
        }

        public bool VerifyUsersCommentOnPost(Comment comment)
        {
            Post? GetPost = _unitOfWork.postRepository.GetPostById(comment.PostId);

            if (GetPost == null)
            {
                return false;
            }
            User? GetUser = _unitOfWork.userRepository.GetUser(comment.UserId);

            if (GetUser == null)
            {
                return false;
            }
            return true;
        }
    }
}
