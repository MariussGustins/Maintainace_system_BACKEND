using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using AutoMapper;
using System.IO;
using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;


namespace Maintainace_system_BACKEND.Services
{
    public class FilesService : IFilesService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public FilesService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<FilesDto> CreateFileMetadataAsync(FilesDto fileDto)
        {
            var fileEntity = _mapper.Map<Files>(fileDto);
            _context.Files.Add(fileEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<FilesDto>(fileEntity);
        }


        public async Task<IEnumerable<FilesDto>> GetFilesByEmployeeIdAsync(int employeeId)
        {
            // Query the database for files with the given EmployeeIdentId
            var files = await _context.Files
                .Where(file => file.EmployeeIdentId == employeeId)
                .ToListAsync();

            // Map the result to DTOs
            return _mapper.Map<IEnumerable<FilesDto>>(files);
        }


    }
}