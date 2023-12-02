using System.ComponentModel;

namespace HealthManager.Models.ViewModels
{
    public class DevicesViewModel
    {
        [DisplayName("Nazwa urządzenia")]
        public string? Name { get; set; }
        [DisplayName("Opis")]
        public string? Description { get; set; }
        [DisplayName("Gotowe do mierzenia")]
        public bool CanSaveMeasures { get; set; }
        [DisplayName("Połączenie")]
        public bool NeedConnection { get; set; }
        public string? UserId { get; set; }
        public int? Id { get; set; }

    }
}
