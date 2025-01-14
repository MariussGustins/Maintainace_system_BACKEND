using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using Maintainace_system_BACKEND.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maintainace_system_BACKEND.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeRolesController : ControllerBase
{
    private readonly IEmployeeRolesService _employeeRolesService;

    public EmployeeRolesController(IEmployeeRolesService employeeRolesService)
    {
        _employeeRolesService = employeeRolesService;
    }

    // Pievieno jaunu darbinieku lomu
    [HttpPost]
    public async Task<IActionResult> AddEmployeeRole([FromBody] EmployeeRolesDto employeeRoleDto)
    {
        var result = await _employeeRolesService.AddEmployeeRole(employeeRoleDto);
        return Ok(result);
    }

    // Iegūst visas darbinieku lomas
    [HttpGet]
    public async Task<IActionResult> GetAllEmployeeRoles()
    {
        var roles = await _employeeRolesService.GetAllEmployeeRoles();
        return Ok(roles);
    }

    // Iegūst lomu pēc ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeRoleById(int id)
    {
        var role = await _employeeRolesService.GetEmployeeRoleById(id);
        if (role == null) return NotFound("Loma netika atrasta.");
        return Ok(role);
    }

    // Dzēš darbinieku lomu
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployeeRole(int id)
    {
        var result = await _employeeRolesService.DeleteEmployeeRole(id);
        if (!result) return NotFound("Loma netika atrasta.");
        return Ok("Loma veiksmīgi izdzēsta.");
    }
}