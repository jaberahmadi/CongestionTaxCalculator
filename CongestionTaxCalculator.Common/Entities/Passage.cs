namespace CongestionTaxCalculator.Common.Entities
{
    public class Passage
    {
        public int PassageId { get; set; }
        public DateTime TimeOfPassage { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}