using HealthManager.Data.Entities;
using HealthManager.Repositories;
using HealthManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HealthManager.Models.ViewModels;

namespace HealthManager.Controllers
{
    public class MeasurementEntitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMeasurementRepository _repo;

        public MeasurementEntitiesController(ApplicationDbContext context, IMeasurementRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            List<MeasurementsViewModel> vm = _repo.GetAllMeasurements(userId).Select(i => new MeasurementsViewModel()
            {
                DateTime = i.DateTime,
                Comment = i.Comment,
                Value = i.Value,
                Id = i.Id

            }).ToList();
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.MeasurementEntity == null)
            {
                return NotFound();
            }
            var measurementEntity = _repo.GetMeasurementById(id);
            MeasurementsViewModel vm = new MeasurementsViewModel()
            {
                DateTime = measurementEntity.DateTime,
                Comment = measurementEntity.Comment,
                Value = measurementEntity.Value,
                Id = measurementEntity.Id

            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create(MeasurementsViewModel measurementEntity)
        {
           
            MeasurementsViewModel vm = new MeasurementsViewModel()
            {
                DateTime = measurementEntity.DateTime,
                Comment = measurementEntity.Comment,
                Value = measurementEntity.Value,
                Id = measurementEntity.Id,
                UserId = measurementEntity.UserId
                

            };
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,Comment,Value")] MeasurementEntity measurementEntity)
        {

            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            _repo.AddMeasurement(userId, measurementEntity);

            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.MeasurementEntity == null)
            {
                return NotFound();
            }
            var measurementEntity = _repo.GetMeasurementById(id);       
            MeasurementsViewModel vm = new MeasurementsViewModel()
            {
                DateTime = measurementEntity.DateTime,
                Comment = measurementEntity.Comment,
                Value = measurementEntity.Value,
                Id = measurementEntity.Id,
                UserId = measurementEntity.UserId
            };
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,Comment,Value,UserId")] MeasurementEntity measurementEntity)
        {
            if (id != measurementEntity.Id)
            {
                return NotFound();
            }
            _repo.UpdateMeasurement(measurementEntity);
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.MeasurementEntity == null)
            {
                return NotFound();
            }


            var measurementEntity = _repo.GetMeasurementById(id);
            MeasurementsViewModel vm = new MeasurementsViewModel()
            {
                DateTime = measurementEntity.DateTime,
                Comment = measurementEntity.Comment,
                Value = measurementEntity.Value,
                Id = measurementEntity.Id,
                UserId = measurementEntity.UserId
            };


            return View(vm);
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeasurementEntity == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MeasurementEntity'  is null.");
            }

            _repo.DeleteMeasurement(id);
            return RedirectToAction(nameof(Index));
        }


    }
}