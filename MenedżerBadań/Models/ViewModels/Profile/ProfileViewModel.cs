using HealthManager.Data.Entities;
using System.Drawing;

namespace HealthManager.Models.ViewModels { 
public class ProfileViewModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    public BloodType? BloodType { get; set; }
    public string UserId { get; set; }
    public int Id { get; set; }
}
}