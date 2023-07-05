using System;
using Microsoft.EntityFrameworkCore;
using ritweek.solution.webapi.common.Model;

namespace ritweek.solution.webapi.db
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeeRepository(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            try
            {
                return await _dbContext.Employees.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("Error occurred while fetching employees.", ex);
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            try
            {
                return await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("Error occurred while fetching an employee by ID.", ex);
            }
        }

        public async Task<Employee> GetEmployeeByUniqueCombinationAsync(string firstName, string lastName, string emailAddress)
        {
            try
            {
                return await _dbContext.Employees.FirstOrDefaultAsync(e => e.FirstName == firstName && e.LastName == lastName && e.EmailAddress == emailAddress).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("Error occurred while fetching an employee by unique combination.", ex);
            }
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            try
            {
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                return employee;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("Error occurred while adding an employee.", ex);
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _dbContext.Employees.Update(employee);
                await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("Error occurred while updating an employee.", ex);
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            try
            {
                var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    await _dbContext.SaveChangesAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new Exception("Error occurred while deleting an employee.", ex);
            }
        }
    }
}

