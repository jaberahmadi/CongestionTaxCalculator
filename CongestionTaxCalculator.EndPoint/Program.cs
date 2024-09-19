
using CongestionTaxCalculator.Business.Definitions;
using CongestionTaxCalculator.Business.Implementations;
using CongestionTaxCalculator.DataAccess;
using CongestionTaxCalculator.DataAccess.MSSQL;
using CongestionTaxCalculator.DataAccess.MSSQL.Repositories;
using CongestionTaxCalculator.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.EndPoint
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CongestionTaxCalculatorDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("CongestionTaxDB")));


            //Inject Dependency
            builder.Services.AddTransient<IUnitOfWork, SqlUnitOfWork>();
            builder.Services.AddTransient<ICongestionTaxCalculatorService, CongestionTaxCalculatorService>();
            builder.Services.AddTransient<IPassageService, PassageService>();
            builder.Services.AddTransient<IVehicleService, VehicleService>();
            builder.Services.AddTransient<IPassageRepository, PassageRepository>();
            builder.Services.AddTransient<ITaxRuleRepository, TaxRuleRepository>();
            builder.Services.AddTransient<ITollFreeDayRuleRepository, TollFreeDayRuleRepository>();
            builder.Services.AddTransient<ITollFreeVehicleRepository, TollFreeVehicleRepository>();
            builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
