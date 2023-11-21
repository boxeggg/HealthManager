using HealthManager.Data.Entities;
using HealthManager.Data;


namespace HealthManager.Repositories
{
    public interface IDeviceRepository
    {
        DeviceEntity GetDeviceById(int id);
        bool DeleteDevice(int id);
        bool AddDevice(DeviceEntity deviceEntity);
        bool UpdateDevice(DeviceEntity deviceEntity);
        List<DeviceEntity> GetAllDevices();
    }

    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;

        public DeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool DeleteDevice(int id)
        {
            var model = GetDeviceById(id);
            _context.DeviceEntity.Remove(model);
            return _context.SaveChanges() > 0;
        }

        public List<DeviceEntity> GetAllDevices()
        {
            return _context.DeviceEntity.Select(n => n).ToList();
        }

        public DeviceEntity GetDeviceById(int id)
        {
            return _context.DeviceEntity.FirstOrDefault(n => n.Id == id);
        }

        public bool AddDevice(DeviceEntity model)
        {
            _context.DeviceEntity.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateDevice(DeviceEntity model)
        {
            _context.DeviceEntity.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}