using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using Maintainace_system_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Maintainace_system_BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly DataContext _context;


        public EmployeeController(IEmployeeService employeeService, DataContext context)
        {
            _employeeService = employeeService;
            _context = context;
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
        [HttpGet("{employeeId}")]
        public async Task<ActionResult> GetEmployeeById(int employeeId)
        {
            try
            {
                // Izmantojam servisu, lai iegūtu darbinieka datus
                var employee = await _employeeService.GetEmployeeByIdAsync(employeeId);

                if (employee == null)
                {
                    return NotFound(new { message = "Employee not found." });
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
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
            var matchedEmployee = await _context.EmployeeIdents
                .Include(ei => ei.Employee)
                .ThenInclude(e => e.Role)
                .FirstOrDefaultAsync(ei => ei.Username == loginDto.Username && ei.Password == loginDto.Password);

            if (matchedEmployee == null)
            {
                return Unauthorized(new { message = "Invalid username or password." });
            }

            return Ok(new
            {
                Id = matchedEmployee.Employee?.Id ?? 0,
                Name = matchedEmployee.Employee?.Name ?? "No Name",
                Surname = matchedEmployee.Employee?.Surname ?? "No Surname",
                Role = matchedEmployee.Employee?.Role?.RoleName ?? "No Role",
                PictureUrl = matchedEmployee.Employee?.PictureUrl ?? "No Picture"
            });
        }
    }
}