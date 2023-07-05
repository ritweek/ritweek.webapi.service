using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ritweek.solution.webapi.common.Model;
using ritweek.solution.webapi.provider;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ritweek.solution.webapi.Controllers
{
    [ExcludeFromCodeCoverage]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync().ConfigureAwait(false);
            if (employees.Any())
            {
                var response = new EmployeeResponse<List<Employee>>
                {
                    Title = "Success",
                    StatusCode = 200,
                    Message = "Employees retrieved successfully",
                    Data = (List<Employee>)employees
                };

                return Ok(response);
            }
            else
            {
                var response = new CustomResponse
                {
                    Title = "Error",
                    StatusCode = 404,
                    Message = "No records found"

                };

                return NotFound(response);
            }
        }

        // GET: api/Employee/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id).ConfigureAwait(false);

            if (employee == null)
            {
                var response = new CustomResponse
                {
                    Title = "Error",
                    StatusCode = 404,
                    Message = "Record not found"

                };

                return NotFound(response);
            }

            var EmpResponse = new EmployeeResponse<Employee>
            {
                Title = "Success",
                StatusCode = 200,
                Message = "Employee retrieved successfully",
                Data = employee
            };

            return Ok(EmpResponse);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
        {
            await _employeeService.AddEmployeeAsync(employee).ConfigureAwait(false);

            var response = new CustomResponse
            {
                Title = "Success",
                StatusCode = (int)HttpStatusCode.Created,
                Message = "Employee data is created"
            };

            return StatusCode((int)HttpStatusCode.Created, response);
        }

        // PUT: api/Employee/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            await _employeeService.UpdateEmployeeAsync(employee).ConfigureAwait(false);

            var response = new CustomResponse
            {
                Title = "Success",
                StatusCode = 200,
                Message = "Employee data is updated"
            };

            return Ok(response);
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id).ConfigureAwait(false);

            var response = new CustomResponse
            {
                Title = "Success",
                StatusCode = 200,
                Message = "Employee data is deleted"
            };

            return Ok(response);
        }

    }

}

