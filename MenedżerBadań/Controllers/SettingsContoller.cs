using Microsoft.AspNetCore.Mvc;

namespace MenedżerBadań.Controllers
{
    public class Settings : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
