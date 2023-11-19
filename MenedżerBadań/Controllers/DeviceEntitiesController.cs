using HealthManager.Data.Entities;
using HealthManager.Repositories;
using MenedżerBadań.Data;
using Microsoft.AspNetCore.Mvc;

namespace HealthManager.Controllers
{
    public class DeviceEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDeviceRepository _repo;

        public DeviceEntitiesController(ApplicationDbContext context, IDeviceRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(_repo.GetAllDevices());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.DeviceEntity == null)
            {
                return NotFound();
            }

            var deviceEntity = _repo.GetDeviceById(id);
            return View(deviceEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,Comment,Value")] DeviceEntity deviceEntity)
        {
            _repo.AddDevice(deviceEntity);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeviceEntity == null)
            {
                return NotFound();
            }

            var deviceEntity = await _context.DeviceEntity.FindAsync(id);
            if (deviceEntity == null)
            {
                return NotFound();
            }

            return View(deviceEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,Comment,Value")] DeviceEntity deviceEntity)
        {
            if (id != deviceEntity.Id)
            {
                return NotFound();
            }

            _repo.UpdateDevice(deviceEntity);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.DeviceEntity == null)
            {
                return NotFound();
            }

            var deviceEntity = _repo.GetDeviceById(id);
            return View(deviceEntity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeviceEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DeviceEntity' is null.");
            }

            _repo.DeleteDevice(id);
            return RedirectToAction(nameof(Index));
        }
    }
}