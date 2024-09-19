using CongestionTaxCalculator.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Business.Definitions
{
    public interface IVehicleService
    {
        Vehicle? Find(int id);

    }
}
