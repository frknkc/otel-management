using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace otel_management.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
