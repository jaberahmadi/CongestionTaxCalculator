using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess.Repositories;
using Elmah;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.DataAccess.MSSQL.Repositories
{
    public class TaxRuleRepository(CongestionTaxCalculatorDbContext context) : ITaxRuleRepository
    {
        public TaxRule? FirstByDate(TimeSpan dateTime)
        {
           return context.TaxRules.FirstOrDefault(r => dateTime >= r.StartTime && dateTime <= r.EndTime);
        }
    }
}
