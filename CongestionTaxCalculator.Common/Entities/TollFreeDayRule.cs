namespace CongestionTaxCalculator.Common.Entities
{

    // Daily exemption rules such as holidays or weekends
    public class TollFreeDayRule
    {
        public int TollFreeDayRuleId { get; set; }
        public DateTime Date { get; set; }  //Exact date of the exemption day
        public DayOfWeek? DayOfWeek { get; set; }  // Specific days like Saturday and Sunday
        public bool IsHoliday { get; set; }  // Is it a public holiday?
    }
}