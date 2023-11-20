using HealthManager.Data.Entities;
using HealthManager.Repositories;
using MenedżerBadań.Controllers;
using MenedżerBadań.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create()
        {
            
            return View();
        }
        public async Task<IActionResult> CreateProfile([Bind("Id,FirstName,LastName,Weight,Height,Bloodtype,UserId")] ProfileEntity model)
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            _repo.AddProfile(userId, model);
            
            return RedirectToAction(nameof(Index));
        }
    }
}
