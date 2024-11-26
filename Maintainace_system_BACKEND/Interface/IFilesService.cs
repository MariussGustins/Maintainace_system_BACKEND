using Maintainace_system_BACKEND.DTOs;

namespace Maintainace_system_BACKEND.Interface
{
    public interface IFilesService
    {
        Task<FilesDto> CreateFileMetadataAsync(FilesDto fileDto);

        Task<IEnumerable<FilesDto>> GetFilesByEmployeeIdAsync(int employeeId);

    }
}