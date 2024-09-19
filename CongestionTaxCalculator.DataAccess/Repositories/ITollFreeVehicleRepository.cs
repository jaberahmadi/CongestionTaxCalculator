namespace CongestionTaxCalculator.DataAccess.Repositories
{
    public interface ITollFreeVehicleRepository
    {
        bool AnyByVehicleType(string vehicleType);
    }
}
