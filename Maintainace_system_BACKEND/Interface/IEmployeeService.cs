using Maintainace_system_BACKEND.DTOs;

namespace Maintainace_system_BACKEND.Interface;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetEmployeeAsync();
    Task<IEnumerable<EmployeeWithIdentDTO>> GetEmployeesWithIdentsAsync();
    Task<int> CreateEmployeeAsync(EmployeeDto employeeDto);

}