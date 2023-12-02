using HealthManager.Data.Entities;
using HealthManager.Repositories;
using HealthManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore.Authorization;
using HealthManager.Models.ViewModels;

namespace HealthManager.Controllers
{
    [Authorize]
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
        public IActionResult Create(ProfileViewModel ProfileEntity)
        {
            if (ProfileEntityExists())
            {
                return NotFound();
            }
            ProfileViewModel vm = new ProfileViewModel()
            {
                FirstName = ProfileEntity.FirstName,
                LastName = ProfileEntity.LastName,
                Height = ProfileEntity.Height,
                Weight = ProfileEntity.Weight,
                BloodType = ProfileEntity.BloodType,

            };
            return View(vm);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            var profileEntity = _repo.GetProfileByUserId(userId);
            ProfileViewModel vm = new ProfileViewModel()
            {
                FirstName = profileEntity.FirstName,
                LastName = profileEntity.LastName,
                Height = profileEntity.Height,
                Weight = profileEntity.Weight,
                BloodType = profileEntity.BloodType,
                UserId = profileEntity.UserId,
                Id = profileEntity.Id

            };
            return View(vm);
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
