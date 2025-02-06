using Maintainace_system_BACKEND.DTOs;
using Maintainace_system_BACKEND.Interface;
using Maintainace_system_BACKEND.Models;
using Microsoft.EntityFrameworkCore;

namespace Maintainace_system_BACKEND.Services;

public class EmployeeRolesService : IEmployeeRolesService
{
    private readonly DataContext _context;

    public EmployeeRolesService(DataContext context)
    {
        _context = context;
    }

    /**
     * Pievieno jaunu darbinieka lomu datu bāzē.
     * @param employeeRoleDto - Jaunās lomas dati DTO formātā.
     * @return Izveidotā darbinieka loma.
     */
    public async Task<EmployeeRoles> AddEmployeeRole(EmployeeRolesDto employeeRoleDto)
    {
        var newRole = new EmployeeRoles
        {
            RoleName = employeeRoleDto.RoleName
        };

        _context.EmployeeRoles.Add(newRole);
        await _context.SaveChangesAsync();
        return newRole;
    }

    /**
     * Iegūst visas darbinieku lomas no datu bāzes.
     * @return Saraksts ar darbinieku lomām.
     */
    public async Task<IEnumerable<EmployeeRoles>> GetAllEmployeeRoles()
    {
        return await _context.EmployeeRoles.ToListAsync();
    }

    /**
     * Iegūst darbinieka lomu pēc ID.
     * @param id - Lomas unikālais identifikators.
     * @return Darbinieka loma vai null, ja loma nav atrasta.
     */
    public async Task<EmployeeRoles?> GetEmployeeRoleById(int id)
    {
        return await _context.EmployeeRoles.FindAsync(id);
    }

    /**
     * Dzēš darbinieka lomu pēc ID.
     * @param id - Lomas unikālais identifikators.
     * @return True, ja loma veiksmīgi dzēsta, false, ja loma nav atrasta.
     */
    public async Task<bool> DeleteEmployeeRole(int id)
    {
        var role = await _context.EmployeeRoles.FindAsync(id);
        if (role == null) return false;

        _context.EmployeeRoles.Remove(role);
        await _context.SaveChangesAsync();
        return true;
    }
}
