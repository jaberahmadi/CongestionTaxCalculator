using CongestionTaxCalculator.Common.Entities;

namespace CongestionTaxCalculator.DataAccess.Repositories
{
    public interface IPassageRepository
    {
        void Add(Passage passage);
        List<Passage> GetByVehicleIdAndDate(int vehicleId, List<DateTime> dateTimes);
        List<Passage> GetByVehicleId(int vehicleId);
    }
}
