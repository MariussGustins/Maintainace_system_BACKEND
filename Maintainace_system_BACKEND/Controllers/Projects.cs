using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Maintainace_system_BACKEND.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectsDto projectDto)
        {
            if (projectDto == null)
                return BadRequest("Project data is required.");

            var createdProject = await _projectsService.CreateProjectAsync(projectDto);
            return Ok(createdProject);
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectsService.GetAllProjectsAsync();
            if (projects == null || !projects.Any())
                return NotFound("No projects found.");

            return Ok(projects);
        }
    }
}