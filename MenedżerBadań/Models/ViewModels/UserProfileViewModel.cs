using HealthManager.Data.Entities;

namespace HealthManager.Models.ViewModels { 
public class UserProfileViewModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Weight { get; set; }
    public string Height { get; set; }
    public BloodType BloodType { get; set; }
}
}
