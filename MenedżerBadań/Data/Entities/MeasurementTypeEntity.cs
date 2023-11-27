namespace HealthManager.Data.Entities
{
    
    public class MeasurementTypeEntity
    {
        public int Id { get; set; }
        public BodyMeasure Name { get; set; }
        public string? Description { get; set; }
        public int SafeRange { get; set; }
        public string? Unit { get; set; }
        public string? ValueTemplate { get; set; }
    }

    public enum BodyMeasure
    {
        Pulse,
        Saturation,
        Weight,
        Height,
        Glucose,
        BloodType,
        Observation,
        Accident,
        Procedure,
    }
}
