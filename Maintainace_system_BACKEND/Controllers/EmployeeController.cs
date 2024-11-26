using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maintainace_system_BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeeAsync();
            return Ok(employees);
        }
        
        [HttpGet("combined")]
        public async Task<ActionResult<IEnumerable<EmployeeWithIdentDTO>>> GetEmployeesWithIdents()
        {
            var combinedData = await _employeeService.GetEmployeesWithIdentsAsync();
            return Ok(combinedData);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> PostEmployee(EmployeeDto employeeDto)
        {
            var employeeId = await _employeeService.CreateEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(GetEmployees), new { id = employeeId }, null);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var employeesWithIdents = await _employeeService.GetEmployeesWithIdentsAsync();
            var matchedEmployee = employeesWithIdents.FirstOrDefault(emp =>
                emp.Username == loginDto.Username && emp.Password == loginDto.Password);

            if (matchedEmployee == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            // For simplicity, no tokens are generated here; integrate with JWT if required
            return Ok(new
            {
                Id = matchedEmployee.Id, // Add Id to EmployeeWithIdentDTO if missing
                Name = matchedEmployee.Name,
                Surname = matchedEmployee.Surname,
                Role = "Employee", // Hardcoded role; replace with dynamic role if needed
            });
        }
    }
}