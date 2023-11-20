using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthManager.Data.Entities;
using HealthManager.Repositories;
using MenedżerBadań.Data;

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


            return View(_repo.GetDeviceById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CanSaveMeasures,NeedConnection")] DeviceEntity deviceEntity)
        {

            _repo.AddDevice(deviceEntity);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.DeviceEntity == null)
            {
                return NotFound();
            }

            return View(_repo.GetDeviceById(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CanSaveMeasures,NeedConnection")] DeviceEntity deviceEntity)
        {
            if (id != deviceEntity.Id)
            {
                return NotFound();
            }

            _repo.UpdateDevice(deviceEntity);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.DeviceEntity == null)
            {
                return NotFound();
            }

            return View(_repo.GetDeviceById(id));
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeviceEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Device'  is null.");
            }

            _repo.DeleteDevice(id);

            return RedirectToAction(nameof(Index));
        }

        private bool DeviceEntityExists(int id)
        {
          return (_context.DeviceEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
