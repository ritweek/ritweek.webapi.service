using System;
using ritweek.solution.webapi.common.Model;

namespace ritweek.solution.webapi.db
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int employeeId);
        Task<Employee> GetEmployeeByUniqueCombinationAsync(string firstName, string lastName, string emailAddress);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int employeeId);
    }
}

