using Maintainace_system_BACKEND.DTOs;

namespace Maintainace_system_BACKEND.Interface;

public interface IProjectsService
{
    /**
     * Izveido jaunu projektu.
     * @param projectDto - Jaunā projekta dati DTO formātā.
     * @return Izveidotā projekta DTO.
     */
    Task<ProjectsDto> CreateProjectAsync(ProjectsDto projectDto);
    
    /**
     * Iegūst visus projektus.
     * @return Saraksts ar visiem projektiem DTO formātā.
     */
    Task<IEnumerable<ProjectsDto>> GetAllProjectsAsync();
    
    /**
     * Atjaunina esošu projektu pēc ID.
     * @param projectId - Projekta unikālais identifikators.
     * @param projectDto - Atjauninātie projekta dati DTO formātā.
     * @return Atjauninātais projekta DTO vai null, ja projekts nav atrasts.
     */
    Task<ProjectsDto?> UpdateProjectAsync(int projectId, ProjectsDto projectDto);
    
    /**
     * Dzēš projektu pēc ID.
     * @param projectId - Projekta unikālais identifikators.
     * @return True, ja projekts veiksmīgi dzēsts, false, ja projekts nav atrasts.
     */
    Task<bool> DeleteProjectAsync(int projectId);
}