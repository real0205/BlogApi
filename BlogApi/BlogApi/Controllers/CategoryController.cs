using BusinessLogicLayer.IService;
using BusinessLogicLayer.MapperMethods;
using Microsoft.AspNetCore.Mvc;
using DomainLayer.DTO.CategoryDTO;
using DataAccessLayer.UnitOfWorkFolder;
using BusinessLogicLayer.UnitOfWorkServicesFolder;
using Microsoft.AspNetCore.Authorization;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : Controller
    {
        //ICategorieService _categoryZService;
        IUnitOfWorkService _unitOfWork;
        CategoryMapper _categoryZMapper;

        public CategoryController(CategoryMapper categoryZMapper, IUnitOfWorkService unitOfWork)
        {
            //_categoryZService = categoryZService;
            _unitOfWork = unitOfWork;
            _categoryZMapper = categoryZMapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCategory()
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            return Ok(_unitOfWork.categoryService.GetAllCategory());
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

            DomainLayer.Models.BlogModels.Category? category = _unitOfWork.categoryService.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }


           CategoryZDto categoryDto = _categoryZMapper.MapCategoryToCategoryZDto(category);

            return Ok(categoryDto);
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateCategory([FromBody] CategoryZDto category)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }

            DomainLayer.Models.BlogModels.Category mappedCategory = _categoryZMapper.MapCategoryDtoToCategory(category);


            DomainLayer.Models.BlogModels.Category? createdCategory = _unitOfWork.categoryService.CreateCategory(mappedCategory, out string message);

            if (createdCategory == null)
            {
                return BadRequest(message);
            }

            CategoryZDto CreatedCategoryDto = _categoryZMapper.MapCategoryToCategoryZDto(createdCategory);
            return Ok(CreatedCategoryDto);
        }

        [HttpPost]
        [Authorize]
        public IActionResult UpdateCategory([FromBody] CategoryZDto category)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            DomainLayer.Models.BlogModels.Category mappedCategory = _categoryZMapper.MapCategoryDtoToCategory(category);

            DomainLayer.Models.BlogModels.Category? categoryUpdated = _unitOfWork.categoryService.UpdateCategory(mappedCategory, out string message);

            if (categoryUpdated is null)
            {
                return BadRequest(message);
            }

            CategoryZDto UpdatedCategoryDto = _categoryZMapper.MapCategoryToCategoryZDto(categoryUpdated);

            return Ok(UpdatedCategoryDto);
        }

        [HttpDelete]
        [Authorize]
        public IActionResult DeleteCategory([FromBody] DeleteRequestCategoryZDto category)
        {
            var emailClaim = User.Claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email);

            if (emailClaim == null)
            {
                return Unauthorized(new { message = "Invalid token: Email claim missing." });
            }
            DomainLayer.Models.BlogModels.Category mappedCategory = _categoryZMapper.MapDeleteCategoryZRequestToCategoryZ(category);

            bool categoryDeleted = _unitOfWork.categoryService.DeleteCategory(mappedCategory.Id, out string message);

            return Ok(categoryDeleted);
        }

    }
}
