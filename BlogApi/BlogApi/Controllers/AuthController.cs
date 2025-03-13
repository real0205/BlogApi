using BusinessLogicLayer.UnitOfWorkServicesFolder;
using DomainLayer.DTO.AuthDTO;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : Controller
    {
        IUnitOfWorkService _unitOfWorkService;
        public AuthController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [HttpPost]
        public IActionResult UserLogin([FromBody] LoginDTO payload)
        {
            LoginResponse response = _unitOfWorkService.authService.LoginAsync(payload);

            return Ok(response);
        }
    }
}
