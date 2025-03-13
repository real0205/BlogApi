using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.UnitOfWorkServicesFolder;
using DomainLayer.DTO.LikeDTO;
using DomainLayer.Models.BlogModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Windows.Input;

namespace BlogApi.Controllers
{
    public class CommentController : Controller
    {

        IUnitOfWorkService _unitOfWork;
        public CommentController(IUnitOfWorkService unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllComments()
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            return Ok(_unitOfWork.commentService.GetAllComment());
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCommentById(int Userid)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            Comment? UserComments = _unitOfWork.commentService.GetCommentById(Userid);

            if (UserComments == null)
            {
                return NotFound();
            }

            return Ok(UserComments);
        }

        //Comment? CreateComment(Comment comment, out string message);
        [HttpGet]
        [Authorize]
        public IActionResult CreateComment(Comment comment)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            Comment? CreateComment = _unitOfWork.commentService.CreateComment(comment, out string message);

            if (CreateComment == null)
            {
                return NotFound();
            }

            return Ok(CreateComment);
        }

        ////bool DeleteComment(int id, out string message);
        [HttpDelete]
        [Authorize]
        public IActionResult DeleteComment(int id)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            //Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            bool PostDeleted = _unitOfWork.commentService.DeleteComment(id, out string message);

            return Ok(PostDeleted);

        }

        //UpdateCategory(Comment comment, out string message);
        [HttpGet]
        [Authorize]
        public IActionResult UpdateComment(Comment comment)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            //Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            Comment? CommentUpdate = _unitOfWork.commentService.UpdateComment(comment, out string message);

            if (CommentUpdate == null)
            {
                return NotFound();
            }

            return Ok(CommentUpdate);
        }
    }
}
