namespace CongestionTaxCalculator.Common.Entities
{
    // Law regarding tax time and expenses
    public class TaxRule
    {
        public int TaxRuleId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Amount { get; set; }  // Tax expenses over a period of time
    }
}