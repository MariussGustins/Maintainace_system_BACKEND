using Maintainace_system_BACKEND.DTOs;

namespace Maintainace_system_BACKEND.Interface;

public interface IEmployeeIdentService
{
    Task<IEnumerable<EmployeeIdentDto>> GetEmployeeIdentsAsync();
    Task<int> CreateEmployeeIdentAsync(EmployeeIdentDto employeeIdentDto);
}