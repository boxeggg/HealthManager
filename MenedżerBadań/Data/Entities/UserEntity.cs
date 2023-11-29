namespace HealthManager.Data.Entities;
using Microsoft.AspNetCore.Identity;



public class UserEntity : IdentityUser
{
    
    public UserTypeEnum UserType { get; set; } 
    public ProfileEntity? Profile { get; set; }
    public int ProfileID { get; set; }
    public ICollection<MeasurementEntity>? Measurements { get; set; }
    public ICollection<DeviceEntity>? Devices { get; set; }
}

public enum UserTypeEnum
{
    SuperAdmin,
    Admin,
    Client
}
