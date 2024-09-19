using CongestionTaxCalculator.Common.Entities;

namespace CongestionTaxCalculator.DataAccess.Repositories
{
    public interface IVehicleRepository
    {
        Vehicle? GetByType(string type);
        Vehicle? FindById(int id);

    }
}
