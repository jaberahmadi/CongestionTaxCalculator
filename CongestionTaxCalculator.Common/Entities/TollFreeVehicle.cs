namespace CongestionTaxCalculator.Common.Entities
{
    // Tax-exempt vehicles
    public class TollFreeVehicle
    {
        public int TollFreeVehicleId { get; set; }
        public string VehicleType { get; set; }  // Type of exempt vehicle (such as motorbike, diplomat)
    }

}