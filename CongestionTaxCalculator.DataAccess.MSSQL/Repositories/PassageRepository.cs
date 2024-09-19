using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess.Repositories;
using Elmah;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.DataAccess.MSSQL.Repositories
{
    public class PassageRepository(CongestionTaxCalculatorDbContext context) : IPassageRepository
    {
        public void Add(Passage passage)
        {
            context.Passages.Add(passage);
        }

        public List<Passage> GetByVehicleId(int vehicleId)
        {
          return context.Passages.Where(p => p.VehicleId == vehicleId).ToList();
        }

        public List<Passage> GetByVehicleIdAndDate(int vehicleId, List<DateTime> dateTimes)
        {
           return context.Passages
               .Where(p => p.VehicleId == vehicleId && dateTimes.Contains(p.TimeOfPassage.Date))
               .ToList();
        }
    }
}
