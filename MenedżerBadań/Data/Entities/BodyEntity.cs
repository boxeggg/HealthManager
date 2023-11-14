namespace HealthManager.Data.Entities
{
    public class BodyEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int SafeRange { get; set; }
        public string? Unit { get; set; }
        public string? ValueTemplate { get; set; }
    }
}
