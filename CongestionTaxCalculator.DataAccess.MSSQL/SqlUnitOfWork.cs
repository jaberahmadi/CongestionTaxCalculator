using CongestionTaxCalculator.DataAccess.MSSQL.Repositories;
using CongestionTaxCalculator.DataAccess.Repositories;
using Elmah;

namespace CongestionTaxCalculator.DataAccess.MSSQL
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly CongestionTaxCalculatorDbContext _context;

        private IVehicleRepository _vehicleRepository;
        private IPassageRepository _passageRepository;
        private ITollFreeVehicleRepository _tollFreeVehicleRepository;
        private ITaxRuleRepository _taxRuleRepository;
        private ITollFreeDayRuleRepository _tollFreeDayRuleRepository;

        public SqlUnitOfWork()
        {
            _context = new CongestionTaxCalculatorDbContext();
        }
        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                ErrorSignal.FromCurrentContext().Raise(new Exception("Exception Message: " + e.Message + " ,ErrorType:  save change exception"));

            }
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public IVehicleRepository VehicleRepository =>
            _vehicleRepository ??= new VehicleRepository(_context); 
        public IPassageRepository PassageRepository =>
            _passageRepository ??= new PassageRepository(_context);  
        public ITollFreeVehicleRepository TollFreeVehicleRepository =>
            _tollFreeVehicleRepository ??= new TollFreeVehicleRepository(_context);    
        public ITaxRuleRepository TaxRulesRepository =>
            _taxRuleRepository ??= new TaxRuleRepository(_context);  
        public ITollFreeDayRuleRepository TollFreeDayRuleRepository =>
            _tollFreeDayRuleRepository ??= new TollFreeDayRuleRepository(_context);
    }
}