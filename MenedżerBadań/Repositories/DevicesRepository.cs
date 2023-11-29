using HealthManager.Data.Entities;
using HealthManager.Data;



namespace HealthManager.Repositories
{
    public interface IDeviceRepository
    {
        DeviceEntity GetDeviceById(int id);
        bool DeleteDevice(int id);
        bool AddDevice(string userId, DeviceEntity deviceEntity);
        bool UpdateDevice(DeviceEntity deviceEntity);
        List<DeviceEntity> GetAllDevices(string id);
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

        public List<DeviceEntity> GetAllDevices(string id)
        {
            return _context.DeviceEntity.Where(n => n.UserId == id).ToList();
        }

        public DeviceEntity GetDeviceById(int id)
        {
            return _context.DeviceEntity.FirstOrDefault(n => n.Id == id);
        }

        public bool AddDevice(string userId, DeviceEntity model)
        {
            var user = _context.Users.Find(userId);
            model.User = user;
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