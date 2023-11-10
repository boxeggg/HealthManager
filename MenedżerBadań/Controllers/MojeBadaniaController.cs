using Microsoft.AspNetCore.Mvc;

namespace MenedżerBadań.Controllers
{
    public class MojeBadania : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
