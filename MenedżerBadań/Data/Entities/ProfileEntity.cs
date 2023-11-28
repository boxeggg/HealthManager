namespace HealthManager.Data.Entities;


public class ProfileEntity
    {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public BloodType? BloodType { get; set; }
    public UserEntity User { get; set; }
    public string UserId { get; set; }



}
public enum BloodType
{
    APositive,
    ANegative,
    BPositive,
    BNegative,
    ABPositive,
    ABNegative,
    OPositive,
    ONegative
}