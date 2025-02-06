using Maintainace_system_BACKEND.DTOs;

namespace Maintainace_system_BACKEND.Interface
{
    public interface IFilesService
    {
        /**
         * Izveido jaunu faila metadatu ierakstu.
         * @param fileDto - Faila metadatu DTO.
         * @return Izveidotā faila metadati.
         */
        Task<FilesDto> CreateFileMetadataAsync(FilesDto fileDto);

        /**
         * Iegūst failus, kas piesaistīti konkrētam darbiniekam.
         * @param employeeId - Darbinieka unikālais identifikators.
         * @return Saraksts ar failiem vai tukšs saraksts, ja faili nav atrasti.
         */
        Task<IEnumerable<FilesDto>> GetFilesByEmployeeIdAsync(int employeeId);
    }
}