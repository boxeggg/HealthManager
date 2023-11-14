namespace HealthManager.Models
{

    public class UserEntity
    {
        public UserTypeEnum UserType { get; set; }
    }

    public enum UserTypeEnum
    {
        SuperAdmin,
        Admin,
        Client
    }
}
