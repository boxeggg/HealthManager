using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthManager.Data;
using HealthManager.Data.Entities;
using HealthManager.Repositories;
using HealthManager.Models.ViewModels;

namespace HealthManager.Controllers
{
    public class DeviceEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDeviceRepository _repo;

        public DeviceEntitiesController(ApplicationDbContext context, IDeviceRepository repo)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            List<DevicesViewModel> vm = _repo.GetAllDevices(userId).Select(i => new DevicesViewModel()
            {
                Name = i.Name,
                Description = i.Description,
                CanSaveMeasures = i.CanSaveMeasures,
                NeedConnection = i.NeedConnection,
                Id = i.Id
            }).ToList();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.DeviceEntity == null)
            {
                return NotFound();
            }
            var devicesEntity = _repo.GetDeviceById(id);
            DevicesViewModel vm = new DevicesViewModel()
            {
                Name = devicesEntity.Name,
                Description = devicesEntity.Description,
                CanSaveMeasures = devicesEntity.CanSaveMeasures,
                NeedConnection = devicesEntity.NeedConnection,
                UserId = devicesEntity.UserId,
                Id = devicesEntity.Id
            };
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create(DevicesViewModel devicesEntity)
        {
            DevicesViewModel vm = new DevicesViewModel()
            {
            Name = devicesEntity.Name,
            Description = devicesEntity.Description,
            CanSaveMeasures = devicesEntity.CanSaveMeasures,
            NeedConnection = devicesEntity.NeedConnection,
            UserId = devicesEntity.UserId,
            Id = devicesEntity.Id
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CanSaveMeasures,NeedConnection")] DeviceEntity deviceEntity)
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            _repo.AddDevice(userId, deviceEntity);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.DeviceEntity == null)
            {
                return NotFound();
            }
            var deviceEntity = _repo.GetDeviceById(id);
            DevicesViewModel vm = new DevicesViewModel()
            {
                Name = deviceEntity.Name,
                Description = deviceEntity.Description,
                CanSaveMeasures = deviceEntity.CanSaveMeasures,
                NeedConnection = deviceEntity.NeedConnection,
                UserId = deviceEntity.UserId,
                Id = deviceEntity.Id
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CanSaveMeasures,NeedConnection,UserId")] DeviceEntity deviceEntity)
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


            var deviceEntity = _repo.GetDeviceById(id);
            DevicesViewModel vm = new DevicesViewModel()
            {
                Name = deviceEntity.Name,
                Description = deviceEntity.Description,
                CanSaveMeasures = deviceEntity.CanSaveMeasures,
                NeedConnection = deviceEntity.NeedConnection,
                UserId = deviceEntity.UserId,
                Id = deviceEntity.Id
            };


            return View(vm);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeviceEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DeviceEntity'  is null.");
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
