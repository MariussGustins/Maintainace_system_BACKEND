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

        public async Task<ProjectsDto> CreateProjectAsync(ProjectsDto projectDto)
        {
            // Kartē DTO uz modeli
            var project = _mapper.Map<Projects>(projectDto);

            // Saglabā datubāzē
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            // Atgriež saglabāto ierakstu kā DTO
            return _mapper.Map<ProjectsDto>(project);
        }

        public async Task<IEnumerable<ProjectsDto>> GetAllProjectsAsync()
        {
            // Iegūst visus ierakstus no datubāzes
            var projects = await _context.Projects.ToListAsync();

            // Kartē modeļus uz DTO
            return _mapper.Map<IEnumerable<ProjectsDto>>(projects);
        }
    }
}