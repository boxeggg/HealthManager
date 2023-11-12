using Microsoft.AspNetCore.Mvc;

namespace MenedżerBadań.Controllers
{
    public class Devices : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
