using HealthManager.Data.Entities;
using System.Diagnostics.Metrics;

using HealthManager.Data;

namespace HealthManager.Repositories
{
    public interface IMeasurementRepository
    {
        MeasurementEntity GetMeasurementById(int id);
        bool DeleteMeasurement(int id);
        bool AddMeasurement(string userId, MeasurementEntity measurementEntity);
        bool UpdateMeasurement(MeasurementEntity measurementEntity);
        float GetMeasurementValueByName(string userId, BodyMeasure measurementName);
        List<MeasurementEntity> GetAllMeasurements(string id);
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

        public List<MeasurementEntity> GetAllMeasurements(string id)
        {
 
            return _context.MeasurementEntity.Where(n => n.UserId == id).ToList();
        }

        public MeasurementEntity GetMeasurementById(int id)
        {
            return _context.MeasurementEntity.FirstOrDefault(n => n.Id == id);
        }
        public float GetMeasurementValueByName(string userId, BodyMeasure measurementName)
        {
            var measurement = _context.MeasurementEntity
                    .OrderByDescending(n => n.DateTime).FirstOrDefault(n => n.UserId == userId && n.Name == measurementName);
            return measurement?.Value ?? -1; 
        }

        public bool AddMeasurement(string userId, MeasurementEntity model)
        {

            var user = _context.Users.Find(userId);
            model.User = user;
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

