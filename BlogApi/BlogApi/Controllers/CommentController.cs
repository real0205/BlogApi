using AutoMapper;
using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperModel;
using DomainLayer.DTO.CommentDto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentService _commentService;
        IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        [HttpGet("GetComment")]
        public IActionResult GetComment()
        {
            //return Ok(_commentService.GetAllComment()); // action result. That's why it contains ok

            return Ok(_mapper.Map<IList<CommentDto>>(_commentService.GetAllComment()));
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            Comment? comment = _commentService.GetComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            //CommentMapper commentMapper = new CommentMapper();
            //CommentDto commentDto = commentMapper.MapCommentToCommentDto(comment);

            //return Ok(comment);

            return Ok(_mapper.Map<CommentDto>(comment));
        }

        [HttpPost("CreateComment")]
        public IActionResult CreateComment([FromBody] CreateRequestCommentDto comment)
        {
            CommentMapper commentMapper = new CommentMapper();
            Comment mappedComment = commentMapper.MapCommentRequestToComment(comment);

            Comment? createdComment = _commentService.CreateComment(mappedComment, out string message);
            if (createdComment == null)
            {
                return BadRequest(message);
            }

            CommentDto commentDto = commentMapper.MapCommentToCommentDto(createdComment);
            return Ok(createdComment);
        }

        [HttpPost("UpdateComment")]
        public IActionResult UpdateComment([FromBody] UpdateCommentDto comment)
        {
            CommentMapper commentMapper = new CommentMapper();
            Comment resultOfmapping = commentMapper.MapUpdateCommentDtoToComment(comment);

            Comment? commentUpdated = _commentService.UpdateComment(resultOfmapping, out string message);



            if (commentUpdated == null)
            {
                return BadRequest(message);
            }

            CommentDto commentDto = commentMapper.MapCommentToCommentDto(commentUpdated);

            return Ok(commentDto);
        }
    }
}
