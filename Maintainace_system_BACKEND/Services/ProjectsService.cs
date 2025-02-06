using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using AutoMapper;
using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace Maintainace_system_BACKEND.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProjectsService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /**
         * Izveido jaunu projektu un saglabā to datu bāzē.
         * @param projectDto - Jaunā projekta dati DTO formātā.
         * @return Izveidotā projekta DTO.
         */
        public async Task<ProjectsDto> CreateProjectAsync(ProjectsDto projectDto)
        {
            // Kartē DTO uz modeli
            var project = _mapper.Map<Projects>(projectDto);

            // Saglabā datu bāzē
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            // Atgriež saglabāto ierakstu kā DTO
            return _mapper.Map<ProjectsDto>(project);
        }

        /**
         * Iegūst visus projektus no datu bāzes.
         * @return Saraksts ar visiem projektiem DTO formātā.
         */
        public async Task<IEnumerable<ProjectsDto>> GetAllProjectsAsync()
        {
            // Iegūst visus ierakstus no datu bāzes
            var projects = await _context.Projects.ToListAsync();

            // Kartē modeļus uz DTO
            return _mapper.Map<IEnumerable<ProjectsDto>>(projects);
        }

        /**
         * Atjaunina esošu projektu pēc ID.
         * @param projectId - Projekta unikālais identifikators.
         * @param projectDto - Atjauninātie projekta dati DTO formātā.
         * @return Atjauninātais projekta DTO vai null, ja projekts nav atrasts.
         */
        public async Task<ProjectsDto?> UpdateProjectAsync(int projectId, ProjectsDto projectDto)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null) return null;

            // Atjaunina projekta informāciju
            project.ProjectName = projectDto.ProjectName;
            project.Description = projectDto.Description;
            project.StartDate = projectDto.StartDate;
            project.EndDate = projectDto.EndDate;
            project.IsActive = projectDto.IsActive;

            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectsDto>(project);
        }

        /**
         * Dzēš projektu pēc ID.
         * @param projectId - Projekta unikālais identifikators.
         * @return True, ja projekts veiksmīgi dzēsts, false, ja projekts nav atrasts.
         */
        public async Task<bool> DeleteProjectAsync(int projectId)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project == null) return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
