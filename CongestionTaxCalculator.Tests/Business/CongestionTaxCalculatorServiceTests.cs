using Moq;
using CongestionTaxCalculator.Business.Implementations;
using CongestionTaxCalculator.Common.Entities;
using CongestionTaxCalculator.DataAccess;

namespace CongestionTaxCalculator.Tests.Business
{
    public class CongestionTaxCalculatorServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CongestionTaxCalculatorService _service;

        public CongestionTaxCalculatorServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _service = new CongestionTaxCalculatorService(_mockUnitOfWork.Object);
        }

        [Fact]
        public void GetTax_InvalidVehicleType_ThrowsArgumentException()
        {
            // Arrange
            var dates = new List<DateTime> { DateTime.Now };
            const string vehicleType = "UnknownVehicleType";

            _mockUnitOfWork.Setup(uow => uow.VehicleRepository.GetByType(vehicleType)).Returns((Vehicle)null);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _service.GetTax(dates, vehicleType));
            Assert.Equal("Invalid vehicle type", exception.Message);
        }

        [Fact]
        public void GetTax_ValidData_CalculatesTaxCorrectly()
        {
            // Arrange
            var vehicle = new Vehicle { VehicleId = 1, VehicleType = "Car" };
            var passages = new List<Passage>
            {
                new Passage { VehicleId = 1, TimeOfPassage = new DateTime(2013, 2, 8, 7, 0, 0) },
                new Passage { VehicleId = 1, TimeOfPassage = new DateTime(2013, 2, 8, 8, 15, 0) }
            };

            _mockUnitOfWork.Setup(uow => uow.VehicleRepository.GetByType("Car")).Returns(vehicle);
            _mockUnitOfWork.Setup(uow => uow.PassageRepository.GetByVehicleIdAndDate(vehicle.VehicleId, It.IsAny<List<DateTime>>()))
                .Returns(passages);

            _mockUnitOfWork.Setup(uow => uow.TollFreeVehicleRepository.AnyByVehicleType(vehicle.VehicleType)).Returns(false);

            _mockUnitOfWork.Setup(uow => uow.TaxRulesRepository.FirstByDate(new TimeSpan(7, 0, 0)))
                .Returns(new TaxRule { Amount = 18 });

            _mockUnitOfWork.Setup(uow => uow.TaxRulesRepository.FirstByDate(new TimeSpan(8, 15, 0)))
                .Returns(new TaxRule { Amount = 8 });

            // Act
            var tax = _service.GetTax(vehicle, passages);

            // Assert
            Assert.Equal(26, tax); // Assumed calculation for the given example
        }

        [Fact]
        public void GetTax_TollFreeVehicle_ReturnsZero()
        {
            // Arrange
            var vehicle = new Vehicle { VehicleId = 1, VehicleType = "Emergency" };
            var passages = new List<Passage>
            {
                new Passage { VehicleId = 1, TimeOfPassage = new DateTime(2013, 2, 8, 7, 0, 0) }
            };

            _mockUnitOfWork.Setup(uow => uow.VehicleRepository.GetByType("Emergency")).Returns(vehicle);
            _mockUnitOfWork.Setup(uow => uow.TollFreeVehicleRepository.AnyByVehicleType(vehicle.VehicleType)).Returns(true);

            // Act
            var tax = _service.GetTax(vehicle, passages);

            // Assert
            Assert.Equal(0, tax);
        }

        [Fact]
        public void GetTax_TollFreeDate_ReturnsZero()
        {
            // Arrange
            var vehicle = new Vehicle { VehicleId = 1, VehicleType = "Car" };
            var passages = new List<Passage>
            {
                new Passage { VehicleId = 1, TimeOfPassage = new DateTime(2013, 1, 1, 7, 0, 0) }
            };

            _mockUnitOfWork.Setup(uow => uow.VehicleRepository.GetByType("Car")).Returns(vehicle);
            _mockUnitOfWork.Setup(uow => uow.PassageRepository.GetByVehicleIdAndDate(vehicle.VehicleId, It.IsAny<List<DateTime>>()))
                .Returns(passages);

            _mockUnitOfWork.Setup(uow => uow.TollFreeVehicleRepository.AnyByVehicleType(vehicle.VehicleType)).Returns(false);
            _mockUnitOfWork.Setup(uow => uow.TollFreeDayRuleRepository.FirstByDate(It.IsAny<DateTime>())).Returns(new TollFreeDayRule());

            // Act
            var tax = _service.GetTax(vehicle, passages);

            // Assert
            Assert.Equal(0, tax);
        }
    }
}
