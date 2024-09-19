using CongestionTaxCalculator.Business.Definitions;
using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess;

namespace CongestionTaxCalculator.Business.Implementations
{
    public class PassageService(IUnitOfWork unitOfWork) : IPassageService
    {
        public void Add(Passage passage)
        {
             unitOfWork.PassageRepository.Add(passage);
             unitOfWork.Commit(); 
        }

        public List<Passage> GetByVehicleId(int vehicleId)
        {
           return unitOfWork.PassageRepository.GetByVehicleId(vehicleId);
        }
    }
}
