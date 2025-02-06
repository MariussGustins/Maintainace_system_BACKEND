using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Models;

namespace Maintainace_system_BACKEND.Interface;

public interface IEmployeeRolesService
{
    /**
     * Pievieno jaunu darbinieka lomu.
     * @param employeeRoleDto - Jaunās lomas dati DTO formātā.
     * @return Izveidotā darbinieka loma.
     */
    Task<EmployeeRoles> AddEmployeeRole(EmployeeRolesDto employeeRoleDto);
    
    /**
     * Iegūst visas darbinieku lomas.
     * @return Saraksts ar darbinieku lomām.
     */
    Task<IEnumerable<EmployeeRoles>> GetAllEmployeeRoles();
    
    /**
     * Iegūst konkrētu darbinieka lomu pēc ID.
     * @param id - Lomas unikālais identifikators.
     * @return Darbinieka loma vai null, ja loma nav atrasta.
     */
    Task<EmployeeRoles?> GetEmployeeRoleById(int id);
    
    /**
     * Dzēš darbinieka lomu pēc ID.
     * @param id - Lomas unikālais identifikators.
     * @return True, ja loma veiksmīgi dzēsta, false, ja loma nav atrasta.
     */
    Task<bool> DeleteEmployeeRole(int id);
}