using CongestionTaxCalculator.Business.Definitions;
using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.EndPoint.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CongestionTaxCalculator.Tests.EndPoint
{
    public class TaxControllerTests
    {
        private readonly Mock<ICongestionTaxCalculatorService> _mockCalculatorService;
        private readonly Mock<IVehicleService> _mockVehicleService;
        private readonly Mock<IPassageService> _mockPassageService;
        private readonly TaxController _controller;

        public TaxControllerTests()
        {
            _mockCalculatorService = new Mock<ICongestionTaxCalculatorService>();
            _mockVehicleService = new Mock<IVehicleService>();
            _mockPassageService = new Mock<IPassageService>();
            _controller = new TaxController(_mockCalculatorService.Object, _mockVehicleService.Object, _mockPassageService.Object);
        }

        [Fact]
        public void AddPassage_ValidPassage_ReturnsOk()
        {
            // Arrange
            var passage = new Passage { VehicleId = 1, TimeOfPassage = DateTime.Now };
            _mockVehicleService.Setup(s => s.Find(passage.VehicleId)).Returns(new Vehicle { VehicleId = 1, VehicleType = "Car" });

            // Act
            var result = _controller.AddPassage(passage);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Passage added successfully.", okResult.Value);
        }

        [Fact]
        public void AddPassage_InvalidVehicle_ReturnsNotFound()
        {
            // Arrange
            var passage = new Passage { VehicleId = 999, TimeOfPassage = DateTime.Now };
            _mockVehicleService.Setup(s => s.Find(passage.VehicleId)).Returns((Vehicle)null);

            // Act
            var result = _controller.AddPassage(passage);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Vehicle not found.", notFoundResult.Value);
        }

        [Fact]
        public void GetTax_ValidData_ReturnsTax()
        {
            // Arrange
            var dates = new List<DateTime> { DateTime.Now };
            const string vehicleType = "Car";
            const int tax = 30;

            _mockCalculatorService.Setup(s => s.GetTax(dates, vehicleType)).Returns(tax);

            // Act
            var result = _controller.GetTax(dates, vehicleType);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tax, okResult.Value);
        }

        [Fact]
        public void GetTax_InvalidVehicleType_ReturnsBadRequest()
        {
            // Arrange
            var dates = new List<DateTime> { DateTime.Now };
            const string vehicleType = "UnknownVehicleType";

            _mockCalculatorService.Setup(s => s.GetTax(dates, vehicleType)).Throws(new ArgumentException("Invalid vehicle type"));

            // Act
            var result = _controller.GetTax(dates, vehicleType);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid vehicle type", badRequestResult.Value);
        }

        [Fact]
        public void GetTax_ByVehicleId_ValidData_ReturnsTax()
        {
            // Arrange
            const int vehicleId = 1;
            var vehicle = new Vehicle { VehicleId = 1, VehicleType = "Car" };
            var passages = new List<Passage> { new Passage { VehicleId = 1, TimeOfPassage = DateTime.Now } };
            const int tax = 30;

            _mockVehicleService.Setup(s => s.Find(vehicleId)).Returns(vehicle);
            _mockPassageService.Setup(s => s.GetByVehicleId(vehicleId)).Returns(passages);
            _mockCalculatorService.Setup(s => s.GetTax(vehicle, passages)).Returns(tax);

            // Act
            var result = _controller.GetTax(vehicleId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tax, okResult.Value);
        }

        [Fact]
        public void GetTax_ByVehicleId_VehicleNotFound_ReturnsNotFound()
        {
            // Arrange
            const int vehicleId = 1;

            _mockVehicleService.Setup(s => s.Find(vehicleId)).Returns((Vehicle)null);

            // Act
            var result = _controller.GetTax(vehicleId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Vehicle or passages not found.", notFoundResult.Value);
        }

        [Fact]
        public void GetTax_ByVehicleId_NoPassages_ReturnsNotFound()
        {
            // Arrange
            const int vehicleId = 1;
            var vehicle = new Vehicle { VehicleId = 1, VehicleType = "Car" };

            _mockVehicleService.Setup(s => s.Find(vehicleId)).Returns(vehicle);
            _mockPassageService.Setup(s => s.GetByVehicleId(vehicleId)).Returns(new List<Passage>());

            // Act
            var result = _controller.GetTax(vehicleId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Vehicle or passages not found.", notFoundResult.Value);
        }
    }
}
