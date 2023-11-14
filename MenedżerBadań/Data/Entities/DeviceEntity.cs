namespace HealthManager.Data.Entities
{
    public class DeviceEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool CanSaveMeasures { get; set; }
        public bool NeedConnection { get; set; }
    }
}
