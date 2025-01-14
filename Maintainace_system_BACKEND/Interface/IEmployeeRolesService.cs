using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Models;

namespace Maintainace_system_BACKEND.Interface;

public interface IEmployeeRolesService
{
    Task<EmployeeRoles> AddEmployeeRole(EmployeeRolesDto employeeRoleDto);
    Task<IEnumerable<EmployeeRoles>> GetAllEmployeeRoles();
    Task<EmployeeRoles?> GetEmployeeRoleById(int id);
    Task<bool> DeleteEmployeeRole(int id);
}