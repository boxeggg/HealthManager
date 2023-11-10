using MenedżerBadań.Models;
using MenedżerBadań.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MenedżerBadań.Controllers
{
    public class MojeBadania : Controller
    {
        private List<Badania> listaBadan = new List<Badania>()
        {
            new Badania{ Id = 0, Name = "Poziom glukozy we krwi"},
            new Badania{ Id = 1, Name = "Ciśnienie krwi"},
            new Badania{ Id = 3, Name = "Morforlogia krwi"},
            new Badania{ Id = 4, Name = "Koagulogram"},
        };
        public IActionResult Index()
        {
            MojeBadaniaViewData vm = new MojeBadaniaViewData();
            vm.Badania = listaBadan;
            return View(vm);
        }
    }
}
