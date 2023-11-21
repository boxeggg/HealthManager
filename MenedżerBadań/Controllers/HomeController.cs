using HealthManager.Models.ViewModels;
using HealthManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HealthManager.Data.Entities;

namespace MenedżerBadań.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }
         

        public IActionResult Index()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var profile = _context.ProfileEntity.FirstOrDefault(n => n.UserId == user.Id);

            return View(new HomeViewModel()
            {
                User = user,
                Profile = profile
                
            });
          
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}