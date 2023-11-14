
using Microsoft.AspNetCore.Mvc;


namespace MenedżerBadań.Controllers
{
    public class MyTests : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}
