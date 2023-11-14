namespace HealthManager.Data.Entities;



public class UserEntity 
{
    public int Id { get; set; }
    public UserTypeEnum UserType { get; set; } 
}

public enum UserTypeEnum
{
    SuperAdmin,
    Admin,
    Client
}
