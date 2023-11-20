using HealthManager.Data.Entities;
using MenedżerBadań.Data;

namespace HealthManager.Repositories
{
    public interface IProfileRepository
    {
        bool AddProfile(string userId, ProfileEntity profileEntity);
        bool UpdateProfile(ProfileEntity profileEntity);

    }

    public class ProfileRepository: IProfileRepository
    {
        private readonly ApplicationDbContext _context;

        public ProfileRepository(ApplicationDbContext context)
        {
            _context = context;
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