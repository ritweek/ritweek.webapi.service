using System;
using Microsoft.Extensions.Logging;
using Moq;
using ritweek.solution.webapi.common.Model;
using ritweek.solution.webapi.db;
using ritweek.solution.webapi.provider;

namespace ritweek.solution.webapi.test
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;
        private Mock<IEmployeeRepository> _mockEmployeeRepository;
        private Mock<ILogger<EmployeeService>> _logger;

        [SetUp]
        public void Setup()
        {
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _logger = new Mock<ILogger<EmployeeService>>();
            _employeeService = new EmployeeService(_mockEmployeeRepository.Object, _logger.Object);
        }

        [Test]
        public async Task GetEmployeesAsync_ShouldReturnListOfEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com" },
                new Employee { EmployeeId = 2, FirstName = "Jane", LastName = "Smith", EmailAddress = "jane.smith@example.com" }
            };

            _mockEmployeeRepository.Setup(repo => repo.GetEmployeesAsync()).ReturnsAsync(employees);

            // Act
            var result = await _employeeService.GetEmployeesAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("John", result.First().FirstName);
            Assert.AreEqual("Jane", result.Last().FirstName);
        }

        [Test]
        public async Task GetEmployeeByIdAsync_ExistingId_ShouldReturnEmployee()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee { EmployeeId = employeeId, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com" };

            _mockEmployeeRepository.Setup(repo => repo.GetEmployeeByIdAsync(employeeId)).ReturnsAsync(employee);

            // Act
            var result = await _employeeService.GetEmployeeByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(employeeId, result.EmployeeId);
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Doe", result.LastName);
        }

        [Test]
        public async Task GetEmployeeByIdAsync_NonExistingId_ShouldReturnNull()
        {
            // Arrange
            var employeeId = 10;

            _mockEmployeeRepository.Setup(repo => repo.GetEmployeeByIdAsync(employeeId)).ReturnsAsync((Employee)null);

            // Act
            var result = await _employeeService.GetEmployeeByIdAsync(employeeId);

            // Assert
            Assert.IsNull(result);
        }

    }
}

