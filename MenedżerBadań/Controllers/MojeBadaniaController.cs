using MenedżerBadań.Models;
using MenedżerBadań.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MenedżerBadań.Controllers
{
    public class MojeBadania : Controller
    {
        private List<Badania> listaBadan = new List<Badania>()
        {
       new Badania { Id = 0, Name = "Pomiar Tętna" },
        new Badania { Id = 1, Name = "Pomiar Pulsu" },
        new Badania { Id = 2, Name = "Pomiar Saturacji" },
        new Badania { Id = 3, Name = "Pomiar Wagi" },
        new Badania { Id = 4, Name = "Pomiar Wzrostu" },
        new Badania { Id = 5, Name = "Zapisywanie Obwodów Ciała" },
        new Badania { Id = 6, Name = "Niepokojące Obserwacje" },
        new Badania { Id = 7, Name = "Pomiar Glukozy we Krwi" },
        new Badania { Id = 8, Name = "Zapis Grupy Krwi" }
        };
        public IActionResult Index()
        {
            MojeBadaniaViewData vm = new MojeBadaniaViewData();
            vm.Badania = listaBadan;
            return View(vm);
        }
    }
}
