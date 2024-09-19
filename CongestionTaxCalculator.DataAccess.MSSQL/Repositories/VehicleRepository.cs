using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess.Repositories;
using Elmah;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.DataAccess.MSSQL.Repositories
{
    public class VehicleRepository(CongestionTaxCalculatorDbContext context) : IVehicleRepository
    {
        public Vehicle? FindById(int id)
        {
            return context.Vehicles.Find(id);
        }

        public Vehicle? GetByType(string type)
        {
          return  context.Vehicles.FirstOrDefault(v => v!.VehicleType == type);
        }
    }
}
