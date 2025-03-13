using AutoMapper;
using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperModel;
using DomainLayer.DTO.CategoryDto;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]    // [controller]/[action] can be used in place of ("GetCategory")
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory()
        {
            //return Ok(_categoryService.GetAllCategory()); 
            return Ok(_mapper.Map<IList<CategoryDto>>(_categoryService.GetAllCategory()));
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            Category? category = _categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            //CategoryMapper categoryMapper = new CategoryMapper();
            //CategoryDto categoryDto = categoryMapper.MapCategoryToCategoryDto(category);

            //return Ok(category);

            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPost("CreateCategory")]
        public IActionResult CreateCategory([FromBody] CreateRequestCategoryDto category)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            Category mappedCategory = categoryMapper.MapCategoryRequestToCategory(category);

            Category? createdCategory = _categoryService.CreateCategory(mappedCategory, out string message);
            if (createdCategory == null)
            {
                return BadRequest(message);
            }

            CategoryDto categoryDto = categoryMapper.MapCategoryToCategoryDto(createdCategory);
            return Ok(createdCategory);
        }

        [HttpPost("UpdateCategory")]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryDto category)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            Category resultOfmapping = categoryMapper.MapUpdateCategoryDtoToCategory(category);

            Category? categoryUpdated = _categoryService.UpdateCategory(resultOfmapping, out string message);



            if (categoryUpdated == null)
            {
                return BadRequest(message);
            }

            CategoryDto categoryDto = categoryMapper.MapCategoryToCategoryDto(categoryUpdated);

            return Ok(categoryDto);
        }
    }
}
