using CongestionTaxCalculator.Common.Entities;

namespace CongestionTaxCalculator.DataAccess.Repositories
{
    public interface ITollFreeDayRuleRepository
    {
        TollFreeDayRule? FirstByDate(DateTime dateTime);
    }
}
