using Microsoft.AspNetCore.Mvc;

namespace otel_management.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
