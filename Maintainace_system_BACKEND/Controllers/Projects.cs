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

        /**
         * Izveido jaunu projektu.
         * @param projectDto - Projekta dati DTO formātā.
         * @return Izveidotā projekta dati vai kļūdas paziņojums.
         */
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] ProjectsDto projectDto)
        {
            if (projectDto == null)
                return BadRequest("Project data is required.");

            var createdProject = await _projectsService.CreateProjectAsync(projectDto);
            return Ok(createdProject);
        }

        /**
         * Iegūst visus projektus.
         * @return Saraksts ar visiem projektiem vai kļūdas paziņojums, ja projekti nav atrasti.
         */
        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectsService.GetAllProjectsAsync();
            if (projects == null || !projects.Any())
                return NotFound("No projects found.");

            return Ok(projects);
        }
        
        /**
         * Atjaunina esošu projektu pēc ID.
         * @param projectId - Projekta ID.
         * @param projectDto - Atjauninātie projekta dati DTO formātā.
         * @return Atjauninātā projekta dati vai kļūdas paziņojums.
         */
        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, [FromBody] ProjectsDto projectDto)
        {
            if (projectDto == null)
                return BadRequest("Project data is required.");

            var updatedProject = await _projectsService.UpdateProjectAsync(projectId, projectDto);
            if (updatedProject == null)
                return NotFound($"Project with ID {projectId} not found.");

            return Ok(updatedProject);
        }

        /**
         * Dzēš projektu pēc ID.
         * @param projectId - Projekta ID.
         * @return Nav saturs vai kļūdas paziņojums, ja projekts nav atrasts.
         */
        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var isDeleted = await _projectsService.DeleteProjectAsync(projectId);
            if (!isDeleted)
                return NotFound($"Project with ID {projectId} not found.");

            return NoContent();
        }
    }
}
