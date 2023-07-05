using Microsoft.Extensions.Logging;
using ritweek.solution.webapi.common.Model;
using ritweek.solution.webapi.db;

namespace ritweek.solution.webapi.provider
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _employeeRepository.GetEmployeesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving employees.");
                throw;
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                return await _employeeRepository.GetEmployeeByIdAsync(employeeId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving an employee by ID. EmployeeId: {EmployeeId}", employeeId);
                throw;
            }
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            try
            {
                var existingEmployee = await _employeeRepository.GetEmployeeByUniqueCombinationAsync(employee.FirstName, employee.LastName, employee.EmailAddress).ConfigureAwait(false);
                if (existingEmployee != null)
                {
                    throw new Exception("An employee with the same combination of first name, last name, and email address already exists.");
                }

                return await _employeeRepository.AddEmployeeAsync(employee).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding an employee.");
                throw;
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                var existingEmployee = await _employeeRepository.GetEmployeeByUniqueCombinationAsync(employee.FirstName, employee.LastName, employee.EmailAddress).ConfigureAwait(false);
                if (existingEmployee != null && existingEmployee.EmployeeId != employee.EmployeeId)
                {
                    throw new Exception("An employee with the same combination of first name, last name, and email address already exists.");
                }

                await _employeeRepository.UpdateEmployeeAsync(employee).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an employee. EmployeeId: {EmployeeId}", employee.EmployeeId);
                throw;
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId).ConfigureAwait(false);
                if (employee == null)
                {
                    throw new Exception("No record found for deletion.");
                }

                await _employeeRepository.DeleteEmployeeAsync(employeeId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an employee. EmployeeId: {EmployeeId}", employeeId);
                throw;
            }
        }
    }
}

