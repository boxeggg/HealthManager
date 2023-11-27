using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MenedżerBadań.Controllers
{
    [Authorize]
    public class Settings : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
