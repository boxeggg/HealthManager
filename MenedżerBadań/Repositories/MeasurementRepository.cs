using HealthManager.Data.Entities;
using System.Diagnostics.Metrics;

using MenedżerBadań.Data;

namespace HealthManager.Repositories
{
    public interface IMeasurementRepository
    {
        MeasurementEntity GetMeasurementById(int id);
        bool DeleteMeasurement(int id);
        bool AddMeasurement(MeasurementEntity measurementEntity);
        bool UpdateMeasurement(MeasurementEntity measurementEntity);
        List<MeasurementEntity> GetAllMeasurements();
    }
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly ApplicationDbContext _context;
        public MeasurementRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool DeleteMeasurement(int id)
        {
            var model = GetMeasurementById(id);
            _context.MeasurementEntity.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public List<MeasurementEntity> GetAllMeasurements()
        {
            return _context.MeasurementEntity.Select(n => n).ToList();
        }

        public MeasurementEntity GetMeasurementById(int id)
        {
            return _context.MeasurementEntity.FirstOrDefault(n => n.Id == id);
        }

        public bool AddMeasurement(MeasurementEntity model)
        {
            _context.MeasurementEntity.Add(model);
            return _context.SaveChanges() > 0;
        }
        public bool UpdateMeasurement(MeasurementEntity model)
        {
            _context.MeasurementEntity.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}

