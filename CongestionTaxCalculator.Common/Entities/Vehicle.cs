namespace CongestionTaxCalculator.Common.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleType { get; set; } // Like Car, Motorbike
        public ICollection<Passage> Passages { get; set; }
    }

}