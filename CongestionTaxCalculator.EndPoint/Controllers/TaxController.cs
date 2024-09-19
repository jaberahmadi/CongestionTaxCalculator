using CongestionTaxCalculator.Business.Definitions;
using CongestionTaxCalculator.Business.Implementations;
using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess;
using CongestionTaxCalculator.DataAccess.MSSQL;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.EndPoint.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxController : ControllerBase
    {
        private readonly ICongestionTaxCalculatorService _calculatorService;
        private readonly IVehicleService _vehicleService;
        private readonly IPassageService _passageService;

        public TaxController(ICongestionTaxCalculatorService calculatorService, IVehicleService vehicleService, IPassageService passageService)
        {
            _calculatorService = calculatorService;
            _vehicleService = vehicleService;
            _passageService = passageService;
        }

        // Generate vehicle pass data
        [HttpPost("AddPassage")]
        public IActionResult AddPassage([FromBody] Passage passage)
        {
            var vehicle = _vehicleService.Find(passage.VehicleId);
            if (vehicle == null)
                return NotFound("Vehicle not found.");

            _passageService.Add(passage);

            return Ok("Passage added successfully.");
        }

        // Calculate tax based on date and vehicle type
        [HttpGet("GetTax")]
        public ActionResult<int> GetTax([FromQuery] List<DateTime> dates, [FromQuery] string vehicleType)
        {
            try
            {
                var tax = _calculatorService.GetTax(dates, vehicleType);
                return Ok(tax);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetTax/{vehicleId}")]
        public ActionResult<int> GetTax(int vehicleId)
        {
            var vehicle = _vehicleService.Find(vehicleId);
            var passages = _passageService.GetByVehicleId(vehicleId);

            if (vehicle == null || passages.Count == 0)
                return NotFound("Vehicle or passages not found.");

            var tax = _calculatorService.GetTax(vehicle, passages);
            return Ok(tax);
        }
    }
}