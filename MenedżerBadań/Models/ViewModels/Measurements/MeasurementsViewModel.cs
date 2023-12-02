using HealthManager.Data.Entities;
using System.ComponentModel;

namespace HealthManager.Models.ViewModels

{
    public class MeasurementsViewModel
    {
       [DisplayName("Data i Czas")]
       public DateTime? DateTime { get; set; }
       [DisplayName("Komentarz")]
       public string? Comment { get; set; }
       [DisplayName("Wartość")]
       public float? Value { get; set; }
       public int Id { get; set; }
       [DisplayName("Nazwa")]
       public BodyMeasure Name { get; set; }
       public string UserId { get; set; }

    }
}
