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

        public FilesService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        /**
         * Izveido jaunu faila metadatu ierakstu datu bāzē.
         * @param fileDto - Faila metadatu DTO.
         * @return Izveidotā faila metadati DTO formātā.
         */
        public async Task<FilesDto> CreateFileMetadataAsync(FilesDto fileDto)
        {
            var fileEntity = _mapper.Map<Files>(fileDto);
            _context.Files.Add(fileEntity);
            await _context.SaveChangesAsync();

            return _mapper.Map<FilesDto>(fileEntity);
        }

        /**
         * Iegūst visus failus, kas saistīti ar konkrētu darbinieku.
         * @param employeeId - Darbinieka unikālais identifikators.
         * @return Saraksts ar failiem DTO formātā.
         */
        public async Task<IEnumerable<FilesDto>> GetFilesByEmployeeIdAsync(int employeeId)
        {
            // Vaicājums datu bāzei, lai atrastu failus ar konkrēto EmployeeIdentId
            var files = await _context.Files
                .Where(file => file.EmployeeIdentId == employeeId)
                .ToListAsync();

            // Kartē iegūtos failus uz DTO
            return _mapper.Map<IEnumerable<FilesDto>>(files);
        }
    }
}
