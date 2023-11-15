using HealthManager.Data.Entities;
using System.Diagnostics.Metrics;

using MenedżerBadań.Data;

namespace HealthManager.Repositories
{
    public interface IMeasurementRepository
    {
        MeasurementEntity GetMeasurementById(int id);
        MeasurementEntity DeleteMeasurement(int id);
        MeasurementEntity InsertMeasurement(MeasurementEntity measurementEntity);
        List<MeasurementEntity> GetAll();
    }
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly ApplicationDbContext _context;
        public MeasurementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public MeasurementEntity DeleteMeasurement(int id)
        {
            throw new NotImplementedException();
        }

        public List<MeasurementEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public MeasurementEntity GetMeasurementById(int id)
        {
            throw new NotImplementedException();
        }

        public MeasurementEntity GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public MeasurementEntity InsertMeasurement(MeasurementEntity measurementEntity)
        {
            throw new NotImplementedException();
        }
    }
}

