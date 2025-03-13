using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.UnitOfWorkServicesFolder;
using DomainLayer.DTO.PostDTO;
using DomainLayer.DTO.UserDTO;
using DomainLayer.Models.BlogModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : Controller
    {
        IUnitOfWorkService _unitOfWork;
        PostMapper _postMapper;

        public PostController(IUnitOfWorkService unitOfWork, PostMapper postMapper)
        {

            _postMapper = postMapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllPosts()
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            return Ok(_unitOfWork.postService.GetAllPost());
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetById(int id)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            Post? post = _unitOfWork.postService.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }


            PostDto postDto = _postMapper.MapPostToPostDto(post);

            return Ok(postDto);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetByAuthorId(int AuthorId)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            List<Post> postList = _unitOfWork.postService.GetPostByAuthorId(AuthorId, out string message);

            if (postList == null)
            {
                return NotFound();
            }

            return Ok(postList);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreatePost([FromBody] CreatePostRequest post)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }

            Post mappedPost = _postMapper.MapCreatePostRequestToUser(post);


            Post? createdPost = _unitOfWork.postService.CreatePost(mappedPost, out string message);

            if (createdPost == null)
            {
                return BadRequest(message);
            }

            PostDto CreatedPostDto = _postMapper.MapPostToPostDto(createdPost);

            return Ok(CreatedPostDto);
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdatePost([FromBody] UpdatePostRequest post)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            Post mappedPost = _postMapper.MapUpdatePostRequestToUser(post);

            Post? PostUpdated = _unitOfWork.postService.UpdatePost(mappedPost, out string message);

            if (PostUpdated is null)
            {
                return BadRequest(message);
            }

            PostDto UpdatedPostDto = _postMapper.MapPostToPostDto(PostUpdated);

            return Ok(UpdatedPostDto);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteUser([FromBody] DeletePostRequest post)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            Post mappedPost = _postMapper.MapDeletePostRequestToCategory(post);

            bool PostDeleted = _unitOfWork.postService.DeletePost(mappedPost.Id, out string message);

            return Ok(PostDeleted);

        }
    }
}
