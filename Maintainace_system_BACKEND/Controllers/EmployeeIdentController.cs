using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maintainace_system_BACKEND.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeIdentController : ControllerBase
{
    private readonly IEmployeeIdentService _employeeIdentService;

    public EmployeeIdentController(IEmployeeIdentService employeeIdentService)
    {
        _employeeIdentService = employeeIdentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeeIdents()
    {
        var employeeIdents = await _employeeIdentService.GetEmployeeIdentsAsync();
        return Ok(employeeIdents);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployeeIdent([FromBody] EmployeeIdentDto employeeIdentDto)
    {
        var id = await _employeeIdentService.CreateEmployeeIdentAsync(employeeIdentDto);
        return CreatedAtAction(nameof(GetEmployeeIdents), new { id }, employeeIdentDto);
    }
}