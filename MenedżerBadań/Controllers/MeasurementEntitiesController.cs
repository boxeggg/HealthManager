
using HealthManager.Data.Entities;
using HealthManager.Repositories;
using MenedżerBadań.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View(_repo.GetAllMeasurements());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.MeasurementEntity == null)
            {
                return NotFound();
            }

            var measurementEntity = _repo.GetMeasurementById(id);
            return View(measurementEntity);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,Comment,Value")] MeasurementEntity measurementEntity)
        {

            _repo.AddMeasurement(measurementEntity);

             return RedirectToAction(nameof(Index));
            
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeasurementEntity == null)
            {
                return NotFound();
            }

            var measurementEntity = await _context.MeasurementEntity.FindAsync(id);
            if (measurementEntity == null)
            {
                return NotFound();
            }
            return View(measurementEntity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,Comment,Value")] MeasurementEntity measurementEntity)
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

            
                var measurementEntity =  _repo.GetMeasurementById(id);
 

                return View(measurementEntity);
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