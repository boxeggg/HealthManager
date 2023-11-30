using System.ComponentModel.DataAnnotations;

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
    [Display(Name = "A+")]
    APositive,
    [Display(Name = "A-")]
    ANegative,
    [Display(Name = "B+")]
    BPositive,
    [Display(Name = "B-")]
    BNegative,
    [Display(Name = "AB+")]
    ABPositive,
    [Display(Name = "AB-")]
    ABNegative,
    [Display(Name = "O+")]
    OPositive,
    [Display(Name = "O-")]
    ONegative
}