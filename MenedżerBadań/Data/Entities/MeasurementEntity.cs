namespace HealthManager.Data.Entities
{
    public class MeasurementEntity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Comment { get; set; }
        public int Value { get; set; }
        public UserEntity User { get; set; }
        public string UserId { get; set; }

    }
}
