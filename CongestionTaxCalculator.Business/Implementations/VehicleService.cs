using CongestionTaxCalculator.Business.Definitions;
using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess;

namespace CongestionTaxCalculator.Business.Implementations
{
    public class VehicleService(IUnitOfWork unitOfWork) : IVehicleService
    {
        public Vehicle? Find(int id)
        {
            return unitOfWork.VehicleRepository.FindById(id);
        }

    }
}
