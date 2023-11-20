

using HealthManager.Data.Entities;

namespace HealthManager.Models.ViewModels

{
    public class MeasurementsViewModel
    {
        public IEnumerable<MeasurementEntity> measurements { get; set; }

    }
}
