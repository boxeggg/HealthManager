using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthManager.Data.Entities
{
    public class MeasurementEntity
    {
        public int Id { get; set; }
        public BodyMeasure Name { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public string? Comment { get; set; }
        public float? Value { get; set; }
        public UserEntity User { get; set; }
        public string UserId { get; set; }

    }
    public enum BodyMeasure
    {
        [Display(Name="Puls")]
        Pulse,
        [Display(Name = "Saturacja")]
        Saturation,
        [Display(Name = "Waga")]
        Weight,
        [Display(Name = "Wzrost")]
        Height,
        [Display(Name = "Poziom glukozy")]
        Glucose,
        [Display(Name = "Typ krwi")]
        BloodType,
        [Display(Name = "Obseracja")]
        Observation,
        [Display(Name = "Wypadek")]
        Accident,
        [Display(Name = "Procedura")]
        Procedure,
    }
}
