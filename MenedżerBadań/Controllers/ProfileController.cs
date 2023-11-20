using HealthManager.Data.Entities;
using HealthManager.Repositories;
using MenedżerBadań.Controllers;
using MenedżerBadań.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace HealthManager.Controllers
{
    public class ProfileController : Controller { 
    private readonly ApplicationDbContext _context;
    private readonly IProfileRepository _repo;
    public ProfileController(ApplicationDbContext context, IProfileRepository repo)
    {
        _context = context;
         _repo = repo;
    }
        [HttpGet]
        public IActionResult Success()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (ProfileEntityExists())
            {
                return NotFound();
            }

            return View();
        }
        [HttpGet]
        public IActionResult Edit()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            return View(_repo.GetProfileByUserId(userId));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(int id, [Bind("Id,FirstName,LastName,Weight,Height,Bloodtype,UserId")] ProfileEntity profileEntity)
        {
            if (id != profileEntity.Id)
            {
                return NotFound();
            }

            _repo.UpdateProfile(profileEntity);

            return RedirectToAction(nameof(Edit));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProfile([Bind("Id,FirstName,LastName,Weight,Height,Bloodtype,UserId")] ProfileEntity model)
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            _repo.AddProfile(userId, model);
            
            return RedirectToAction(nameof(Success));
        }
        private bool ProfileEntityExists()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var id = user.Id;
            return (_context.ProfileEntity?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
