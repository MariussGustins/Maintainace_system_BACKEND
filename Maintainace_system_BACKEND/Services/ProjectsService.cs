using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using AutoMapper;
using Maintainace_system_BACKEND.Models;

namespace Maintainace_system_BACKEND.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IMapper _mapper;

        public ProjectsService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ProjectsDto> CreateProjectAsync(ProjectsDto projectDto)
        {
            // Simulate saving to a database
            var project = _mapper.Map<Projects>(projectDto);
            project.Id = new Random().Next(1, 1000); // Simulated ID generation

            return await Task.FromResult(_mapper.Map<ProjectsDto>(project));
        }
    }
}