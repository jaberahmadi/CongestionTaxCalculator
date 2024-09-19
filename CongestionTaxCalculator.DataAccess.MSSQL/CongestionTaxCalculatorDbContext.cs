using CongestionTaxCalculator.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.DataAccess.MSSQL
{
    public class CongestionTaxCalculatorDbContext : DbContext
    {
        public CongestionTaxCalculatorDbContext() 
        {
            
        }
        public CongestionTaxCalculatorDbContext(DbContextOptions<CongestionTaxCalculatorDbContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Passage> Passages { get; set; }
        public DbSet<TaxRule> TaxRules { get; set; }
        public DbSet<TollFreeVehicle> TollFreeVehicles { get; set; }
        public DbSet<TollFreeDayRule> TollFreeDayRules { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=CongestionTaxDB;Trusted_Connection=True;Encrypt=false;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Default data for tax-exempt vehicles
            modelBuilder.Entity<TollFreeVehicle>().HasData(
                new TollFreeVehicle { TollFreeVehicleId = 1, VehicleType = "Motorbike" },
                new TollFreeVehicle { TollFreeVehicleId = 2, VehicleType = "Emergency" },
                new TollFreeVehicle { TollFreeVehicleId = 3, VehicleType = "Diplomat" },
                new TollFreeVehicle { TollFreeVehicleId = 4, VehicleType = "Foreign" },
                new TollFreeVehicle { TollFreeVehicleId = 5, VehicleType = "Military" }
            );

            // Default data for tax time regulations
            modelBuilder.Entity<TaxRule>().HasData(
                new TaxRule { TaxRuleId = 1, StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(6, 29, 59), Amount = 8 },
                new TaxRule { TaxRuleId = 2, StartTime = new TimeSpan(6, 30, 0), EndTime = new TimeSpan(6, 59, 59), Amount = 13 },
                new TaxRule { TaxRuleId = 3, StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(7, 59, 59), Amount = 18 },
                new TaxRule { TaxRuleId = 4, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 29, 59), Amount = 13 },
                new TaxRule { TaxRuleId = 5, StartTime = new TimeSpan(8, 30, 0), EndTime = new TimeSpan(14, 59, 59), Amount = 8 },
                new TaxRule { TaxRuleId = 6, StartTime = new TimeSpan(15, 0, 0), EndTime = new TimeSpan(15, 29, 59), Amount = 13 },
                new TaxRule { TaxRuleId = 7, StartTime = new TimeSpan(15, 30, 0), EndTime = new TimeSpan(16, 59, 59), Amount = 18 },
                new TaxRule { TaxRuleId = 8, StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(17, 59, 59), Amount = 13 },
                new TaxRule { TaxRuleId = 9, StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(18, 29, 59), Amount = 8 }
            );

            // Default data for holidays and exemptions
            modelBuilder.Entity<TollFreeDayRule>().HasData(
                new TollFreeDayRule { TollFreeDayRuleId = 1, DayOfWeek = DayOfWeek.Saturday },
                new TollFreeDayRule { TollFreeDayRuleId = 2, DayOfWeek = DayOfWeek.Sunday },
                new TollFreeDayRule { TollFreeDayRuleId = 3, Date = new DateTime(2013, 1, 1), IsHoliday = true }
            );

            // Default data for vehicles and their permits
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { VehicleId = 1, VehicleType = "Car" },
                new Vehicle { VehicleId = 2, VehicleType = "Motorbike" }
            );

            modelBuilder.Entity<Passage>().HasData(
                new Passage { PassageId = 1, VehicleId = 1, TimeOfPassage = new DateTime(2013, 1, 14, 6, 23, 27) }, // ماشین در ساعت 06:23
                new Passage { PassageId = 2, VehicleId = 1, TimeOfPassage = new DateTime(2013, 1, 14, 15, 27, 00) }, // ماشین در ساعت 15:27
                new Passage { PassageId = 3, VehicleId = 2, TimeOfPassage = new DateTime(2013, 1, 14, 6, 30, 00) }, // موتور در ساعت 06:30 (معاف)
                new Passage { PassageId = 4, VehicleId = 1, TimeOfPassage = new DateTime(2013, 1, 14, 17, 49, 00) }, // ماشین در ساعت 17:49
                new Passage { PassageId = 5, VehicleId = 2, TimeOfPassage = new DateTime(2013, 1, 14, 8, 0, 0) }     // موتور در ساعت 08:00 (معاف)
            );
        }
    }
}
