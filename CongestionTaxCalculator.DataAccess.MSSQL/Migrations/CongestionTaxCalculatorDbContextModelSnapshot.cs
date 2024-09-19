﻿// <auto-generated />
using System;
using CongestionTaxCalculator.DataAccess.MSSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CongestionTaxCalculator.DataAccess.MSSQL.Migrations
{
    [DbContext(typeof(CongestionTaxCalculatorDbContext))]
    partial class CongestionTaxCalculatorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CongestionTaxCalculator.Common.Entities.Passage", b =>
                {
                    b.Property<int>("PassageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassageId"));

                    b.Property<DateTime>("TimeOfPassage")
                        .HasColumnType("datetime2");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("PassageId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Passages");

                    b.HasData(
                        new
                        {
                            PassageId = 1,
                            TimeOfPassage = new DateTime(2013, 1, 14, 6, 23, 27, 0, DateTimeKind.Unspecified),
                            VehicleId = 1
                        },
                        new
                        {
                            PassageId = 2,
                            TimeOfPassage = new DateTime(2013, 1, 14, 15, 27, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = 1
                        },
                        new
                        {
                            PassageId = 3,
                            TimeOfPassage = new DateTime(2013, 1, 14, 6, 30, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = 2
                        },
                        new
                        {
                            PassageId = 4,
                            TimeOfPassage = new DateTime(2013, 1, 14, 17, 49, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = 1
                        },
                        new
                        {
                            PassageId = 5,
                            TimeOfPassage = new DateTime(2013, 1, 14, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            VehicleId = 2
                        });
                });

            modelBuilder.Entity("CongestionTaxCalculator.Common.Entities.TaxRule", b =>
                {
                    b.Property<int>("TaxRuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxRuleId"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("TaxRuleId");

                    b.ToTable("TaxRules");

                    b.HasData(
                        new
                        {
                            TaxRuleId = 1,
                            Amount = 8,
                            EndTime = new TimeSpan(0, 6, 29, 59, 0),
                            StartTime = new TimeSpan(0, 6, 0, 0, 0)
                        },
                        new
                        {
                            TaxRuleId = 2,
                            Amount = 13,
                            EndTime = new TimeSpan(0, 6, 59, 59, 0),
                            StartTime = new TimeSpan(0, 6, 30, 0, 0)
                        },
                        new
                        {
                            TaxRuleId = 3,
                            Amount = 18,
                            EndTime = new TimeSpan(0, 7, 59, 59, 0),
                            StartTime = new TimeSpan(0, 7, 0, 0, 0)
                        },
                        new
                        {
                            TaxRuleId = 4,
                            Amount = 13,
                            EndTime = new TimeSpan(0, 8, 29, 59, 0),
                            StartTime = new TimeSpan(0, 8, 0, 0, 0)
                        },
                        new
                        {
                            TaxRuleId = 5,
                            Amount = 8,
                            EndTime = new TimeSpan(0, 14, 59, 59, 0),
                            StartTime = new TimeSpan(0, 8, 30, 0, 0)
                        },
                        new
                        {
                            TaxRuleId = 6,
                            Amount = 13,
                            EndTime = new TimeSpan(0, 15, 29, 59, 0),
                            StartTime = new TimeSpan(0, 15, 0, 0, 0)
                        },
                        new
                        {
                            TaxRuleId = 7,
                            Amount = 18,
                            EndTime = new TimeSpan(0, 16, 59, 59, 0),
                            StartTime = new TimeSpan(0, 15, 30, 0, 0)
                        },
                        new
                        {
                            TaxRuleId = 8,
                            Amount = 13,
                            EndTime = new TimeSpan(0, 17, 59, 59, 0),
                            StartTime = new TimeSpan(0, 17, 0, 0, 0)
                        },
                        new
                        {
                            TaxRuleId = 9,
                            Amount = 8,
                            EndTime = new TimeSpan(0, 18, 29, 59, 0),
                            StartTime = new TimeSpan(0, 18, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("CongestionTaxCalculator.Common.Entities.TollFreeDayRule", b =>
                {
                    b.Property<int>("TollFreeDayRuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TollFreeDayRuleId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<bool>("IsHoliday")
                        .HasColumnType("bit");

                    b.HasKey("TollFreeDayRuleId");

                    b.ToTable("TollFreeDayRules");

                    b.HasData(
                        new
                        {
                            TollFreeDayRuleId = 1,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DayOfWeek = 6,
                            IsHoliday = false
                        },
                        new
                        {
                            TollFreeDayRuleId = 2,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DayOfWeek = 0,
                            IsHoliday = false
                        },
                        new
                        {
                            TollFreeDayRuleId = 3,
                            Date = new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsHoliday = true
                        });
                });

            modelBuilder.Entity("CongestionTaxCalculator.Common.Entities.TollFreeVehicle", b =>
                {
                    b.Property<int>("TollFreeVehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TollFreeVehicleId"));

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TollFreeVehicleId");

                    b.ToTable("TollFreeVehicles");

                    b.HasData(
                        new
                        {
                            TollFreeVehicleId = 1,
                            VehicleType = "Motorbike"
                        },
                        new
                        {
                            TollFreeVehicleId = 2,
                            VehicleType = "Emergency"
                        },
                        new
                        {
                            TollFreeVehicleId = 3,
                            VehicleType = "Diplomat"
                        },
                        new
                        {
                            TollFreeVehicleId = 4,
                            VehicleType = "Foreign"
                        },
                        new
                        {
                            TollFreeVehicleId = 5,
                            VehicleType = "Military"
                        });
                });

            modelBuilder.Entity("CongestionTaxCalculator.Common.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            VehicleId = 1,
                            VehicleType = "Car"
                        },
                        new
                        {
                            VehicleId = 2,
                            VehicleType = "Motorbike"
                        });
                });

            modelBuilder.Entity("CongestionTaxCalculator.Common.Entities.Passage", b =>
                {
                    b.HasOne("CongestionTaxCalculator.Common.Entities.Vehicle", "Vehicle")
                        .WithMany("Passages")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("CongestionTaxCalculator.Common.Entities.Vehicle", b =>
                {
                    b.Navigation("Passages");
                });
#pragma warning restore 612, 618
        }
    }
}
