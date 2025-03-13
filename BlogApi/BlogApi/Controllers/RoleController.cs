using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
