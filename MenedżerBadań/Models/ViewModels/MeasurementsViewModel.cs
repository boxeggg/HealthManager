

namespace HealthManager.Models.ViewModels

{
    public class MeasurementsViewModel
    {
       public DateTime? DateTime { get; set; }
       public string? Comment { get; set; }
       public int? Value { get; set; }
       public int Id { get; set; }
       public string UserId { get; set; }

    }
}
