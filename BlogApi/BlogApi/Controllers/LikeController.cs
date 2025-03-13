using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.Service;
using BusinessLogicLayer.UnitOfWorkServicesFolder;
using DomainLayer.DTO.LikeDTO;
using DomainLayer.DTO.PostDTO;
using DomainLayer.Models.BlogModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LikeController : Controller
    {
        IUnitOfWorkService _unitOfWork;
        LikeMapper _likeMapper;
        public LikeController(LikeMapper likeMapper, IUnitOfWorkService unitOfWork)
        {
            _likeMapper = likeMapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllLikes()
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            return Ok(_unitOfWork.likeService.GetAllLikes());
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetLikeByUserId(int Userid)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            List<Like> UserLikes = _unitOfWork.likeService.GetLikeByUserId(Userid, out string message);

            if (!UserLikes.Any())
            {
                return NotFound();
            }

            return Ok(UserLikes);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetLikeByPostId(int PostId)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            List<Like> PostLikes = _unitOfWork.likeService.GetLikeByUserId(PostId, out string message);

            if (!PostLikes.Any())
            {
                return NotFound();
            }

            return Ok(PostLikes);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult Unlike([FromBody] LikeDto LikeDetails)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            bool PostDeleted = _unitOfWork.likeService.UnlikePost(mappedLike, out string message);

            return Ok(PostDeleted);

        }

        [HttpGet]
        [Authorize]
        public IActionResult GetPostByUserIdAndPostId(LikeDto LikeDetails)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            Like mappedLike = _likeMapper.MapLikeDtoToLike(LikeDetails);

            Like LikedPostByUser = _unitOfWork.likeService.GetPostByUserIdAndPostId(mappedLike, out string message);

            if (LikedPostByUser == null)
            {
                return NotFound();
            }

            return Ok(LikedPostByUser);
        }
    }
}
