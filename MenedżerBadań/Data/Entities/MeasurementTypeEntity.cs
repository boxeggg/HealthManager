namespace HealthManager.Data.Entities
{
    
    public class MeasurementTypeEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int SafeRange { get; set; }
        public string? Unit { get; set; }
        public string? ValueTemplate { get; set; }
    }
    public enum MeasurementTypeEnum
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
