using Maintainace_system_BACKEND.DTOs;

namespace Maintainace_system_BACKEND.Interface;

public interface IProjectsService
{
    Task<ProjectsDto> CreateProjectAsync(ProjectsDto projectDto);
    Task<IEnumerable<ProjectsDto>> GetAllProjectsAsync();
}