using CongestionTaxCalculator.Common.Entities;

namespace CongestionTaxCalculator.DataAccess.Repositories
{
    public interface ITaxRuleRepository
    {
        TaxRule? FirstByDate(TimeSpan dateTime);
    }
}
