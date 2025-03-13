using AutoMapper;
using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperModel;
using DomainLayer.DTO.AuthorDto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IAuthorService _authorService;
        IMapper _mapper;
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet("GetAuthor")]
        public IActionResult GetAuthor()
        {
            //return Ok(_authorService.GetAllAuthor()); // action result. That's why it contains ok

            return Ok(_mapper.Map<IList<AuthorDto>>(_authorService.GetAllAuthor()));
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            Author? author = _authorService.GetAuthor(id);

            if (author == null)
            {
                return NotFound();
            }

            //AuthorMapper authorMapper = new AuthorMapper();
            //AuthorDto authorDto = authorMapper.MapAuthorToAuthorDto(author);

            //return Ok(author);

            return Ok(_mapper.Map<AuthorDto>(author));
        }

        [HttpPost("CreateAuthor")]
        public IActionResult CreateAuthor([FromBody] CreateRequestAuthorDto author)
        {
            AuthorMapper authorMapper = new AuthorMapper();
            Author mappedAuthor = authorMapper.MapAuthorRequestToAuthor(author);

            Author? createdAuthor = _authorService.CreateAuthor(mappedAuthor, out string message);
            if (createdAuthor == null)
            {
                return BadRequest(message);
            }

            AuthorDto authorDto = authorMapper.MapAuthorToAuthorDto(createdAuthor);
            return Ok(createdAuthor);
        }

        [HttpPost("UpdateAuthor")]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorDto author)
        {
            AuthorMapper authorMapper = new AuthorMapper();
            Author resultOfmapping = authorMapper.MapUpdateAuthorDtoToAuthor(author);

            Author? authorUpdated = _authorService.UpdateAuthor(resultOfmapping, out string message);



            if (authorUpdated == null)
            {
                return BadRequest(message);
            }

            AuthorDto authorDto = authorMapper.MapAuthorToAuthorDto(authorUpdated);

            return Ok(authorDto);
        }
    }
}
