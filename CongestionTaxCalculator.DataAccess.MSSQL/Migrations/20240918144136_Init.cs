using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CongestionTaxCalculator.DataAccess.MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxRules",
                columns: table => new
                {
                    TaxRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRules", x => x.TaxRuleId);
                });

            migrationBuilder.CreateTable(
                name: "TollFreeDayRules",
                columns: table => new
                {
                    TollFreeDayRuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    IsHoliday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TollFreeDayRules", x => x.TollFreeDayRuleId);
                });

            migrationBuilder.CreateTable(
                name: "TollFreeVehicles",
                columns: table => new
                {
                    TollFreeVehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TollFreeVehicles", x => x.TollFreeVehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });

            migrationBuilder.CreateTable(
                name: "Passages",
                columns: table => new
                {
                    PassageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfPassage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passages", x => x.PassageId);
                    table.ForeignKey(
                        name: "FK_Passages_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaxRules",
                columns: new[] { "TaxRuleId", "Amount", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1, 8, new TimeSpan(0, 6, 29, 59, 0), new TimeSpan(0, 6, 0, 0, 0) },
                    { 2, 13, new TimeSpan(0, 6, 59, 59, 0), new TimeSpan(0, 6, 30, 0, 0) },
                    { 3, 18, new TimeSpan(0, 7, 59, 59, 0), new TimeSpan(0, 7, 0, 0, 0) },
                    { 4, 13, new TimeSpan(0, 8, 29, 59, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 5, 8, new TimeSpan(0, 14, 59, 59, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 6, 13, new TimeSpan(0, 15, 29, 59, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 7, 18, new TimeSpan(0, 16, 59, 59, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { 8, 13, new TimeSpan(0, 17, 59, 59, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { 9, 8, new TimeSpan(0, 18, 29, 59, 0), new TimeSpan(0, 18, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "TollFreeDayRules",
                columns: new[] { "TollFreeDayRuleId", "Date", "DayOfWeek", "IsHoliday" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, false },
                    { 3, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true }
                });

            migrationBuilder.InsertData(
                table: "TollFreeVehicles",
                columns: new[] { "TollFreeVehicleId", "VehicleType" },
                values: new object[,]
                {
                    { 1, "Motorbike" },
                    { 2, "Emergency" },
                    { 3, "Diplomat" },
                    { 4, "Foreign" },
                    { 5, "Military" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "VehicleType" },
                values: new object[,]
                {
                    { 1, "Car" },
                    { 2, "Motorbike" }
                });

            migrationBuilder.InsertData(
                table: "Passages",
                columns: new[] { "PassageId", "TimeOfPassage", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2013, 1, 14, 6, 23, 27, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2013, 1, 14, 15, 27, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2013, 1, 14, 6, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2013, 1, 14, 17, 49, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, new DateTime(2013, 1, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passages_VehicleId",
                table: "Passages",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passages");

            migrationBuilder.DropTable(
                name: "TaxRules");

            migrationBuilder.DropTable(
                name: "TollFreeDayRules");

            migrationBuilder.DropTable(
                name: "TollFreeVehicles");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
