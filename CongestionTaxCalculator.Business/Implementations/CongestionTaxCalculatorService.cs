using CongestionTaxCalculator.Business.Definitions;
using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess;

namespace CongestionTaxCalculator.Business.Implementations
{
    public class CongestionTaxCalculatorService(IUnitOfWork unitOfWork) : ICongestionTaxCalculatorService
    {
        public int GetTax(List<DateTime> dates, string vehicleType)
        {
            var vehicle = unitOfWork.VehicleRepository.GetByType(vehicleType);
            if (vehicle == null)
                throw new ArgumentException("Invalid vehicle type");

            var passages = unitOfWork.PassageRepository.GetByVehicleIdAndDate(vehicle.VehicleId, dates);

            return GetTax(vehicle, passages);
        }

        public int GetTax(Vehicle vehicle, List<Passage> passages)
        {
            if (IsTollFreeVehicle(vehicle))
                return 0;

            var totalTax = 0;
            var intervalStart = passages[0].TimeOfPassage;

            foreach (var passage in passages.OrderBy(p => p.TimeOfPassage))
            {
                var nextFee = GetTollFee(passage.TimeOfPassage, vehicle);
                var tempFee = GetTollFee(intervalStart, vehicle);

                var timeDiff = passage.TimeOfPassage - intervalStart;
                if (timeDiff.TotalMinutes <= 60)
                {
                    if (nextFee > tempFee)
                    {
                        totalTax -= tempFee;
                        totalTax += nextFee;
                    }
                }
                else
                {
                    totalTax += nextFee;
                    intervalStart = passage.TimeOfPassage;
                }

                if (totalTax >= 60)
                    return 60;
            }

            return totalTax;
        }

        private bool IsTollFreeVehicle(Vehicle vehicle)
        {
            return unitOfWork.TollFreeVehicleRepository.AnyByVehicleType(vehicle.VehicleType);
        }

        private int GetTollFee(DateTime date, Vehicle vehicle)
        {
            if (IsTollFreeDate(date))
                return 0;

            var timeOfDay = date.TimeOfDay;
            var rule = unitOfWork.TaxRulesRepository.FirstByDate(timeOfDay);
            return rule?.Amount ?? 0;
        }

        private bool IsTollFreeDate(DateTime date)
        {
            var tollFreeDay = unitOfWork.TollFreeDayRuleRepository.FirstByDate(date);

            return tollFreeDay != null;
        }
    }
}
