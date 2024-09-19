using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess.Repositories;
using Elmah;

namespace CongestionTaxCalculator.DataAccess.MSSQL.Repositories
{
    public class TollFreeVehicleRepository(CongestionTaxCalculatorDbContext context) : ITollFreeVehicleRepository
    {
        public bool AnyByVehicleType(string vehicleType)
        {
           return context.TollFreeVehicles.Any(t => t.VehicleType == vehicleType);
        }
    }
}
