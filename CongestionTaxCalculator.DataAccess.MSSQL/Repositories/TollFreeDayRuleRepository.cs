using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess.Repositories;
using Elmah;

namespace CongestionTaxCalculator.DataAccess.MSSQL.Repositories
{
    public class TollFreeDayRuleRepository(CongestionTaxCalculatorDbContext context) : ITollFreeDayRuleRepository
    {
        public TollFreeDayRule? FirstByDate(DateTime dateTime)
        {
          return context.TollFreeDayRules
              .FirstOrDefault(d => d.DayOfWeek == dateTime.DayOfWeek || d.Date == dateTime.Date);
        }
    }
}
