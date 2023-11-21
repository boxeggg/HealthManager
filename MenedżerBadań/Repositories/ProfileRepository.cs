using HealthManager.Data.Entities;
using HealthManager.Data;

namespace HealthManager.Repositories
{
    public interface IProfileRepository
    {
        bool AddProfile(string userId, ProfileEntity profileEntity);
        bool UpdateProfile(ProfileEntity profileEntity);
        ProfileEntity GetProfileByUserId(string id);

    }

    public class ProfileRepository: IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ProfileEntity GetProfileByUserId(string userId)
        {
            var user = userId;
            return _context.ProfileEntity.FirstOrDefault(n => n.UserId == userId);

        }
        public bool AddProfile(string userId, ProfileEntity model)
        {
            
            var user = _context.Users.Find(userId);
            model.User = user;
            _context.ProfileEntity.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool UpdateProfile(ProfileEntity model)
        {
            _context.ProfileEntity.Update(model);
            return _context.SaveChanges() > 0;
        }
    }
}