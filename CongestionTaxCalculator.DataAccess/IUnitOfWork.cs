using CongestionTaxCalculator.DataAccess.Repositories;

namespace CongestionTaxCalculator.DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        IVehicleRepository VehicleRepository { get; }
        IPassageRepository PassageRepository { get; }
        ITollFreeVehicleRepository TollFreeVehicleRepository { get; }
        ITaxRuleRepository TaxRulesRepository { get; }
        ITollFreeDayRuleRepository TollFreeDayRuleRepository { get; }
        void Commit();
    }
}