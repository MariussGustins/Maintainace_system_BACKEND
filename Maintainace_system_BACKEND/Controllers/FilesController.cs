using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maintainace_system_BACKEND.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilesController : ControllerBase
{
    private readonly IFilesService _filesService;

    public FilesController(IFilesService filesService)
    {
        _filesService = filesService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFileMetadata([FromBody] FilesDto fileDto)
    {
        if (fileDto == null)
            return BadRequest("File metadata is required.");

        var createdFile = await _filesService.CreateFileMetadataAsync(fileDto);
        return Ok(createdFile);
    }
    [HttpGet("by-employee/{employeeId}")]
    public async Task<IActionResult> GetFilesByEmployeeId(int employeeId)
    {
        var files = await _filesService.GetFilesByEmployeeIdAsync(employeeId);

        if (files == null || !files.Any())
            return NotFound($"No files found for Employee ID: {employeeId}");

        return Ok(files);
    }

}