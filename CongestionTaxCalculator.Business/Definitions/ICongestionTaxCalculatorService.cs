using CongestionTaxCalculator.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Business.Definitions
{
    public interface ICongestionTaxCalculatorService
    {
        int GetTax(List<DateTime> dates, string vehicleType);
        int GetTax(Vehicle vehicle, List<Passage> passages);

    }
}
