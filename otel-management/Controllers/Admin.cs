using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace otel_management.Controllers
{
    [Authorize]
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
