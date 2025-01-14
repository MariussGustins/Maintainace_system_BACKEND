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

    // Pievieno jaunu darbinieku lomu
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

    // Atgriež visas darbinieku lomas
    public async Task<IEnumerable<EmployeeRoles>> GetAllEmployeeRoles()
    {
        return await _context.EmployeeRoles.ToListAsync();
    }

    // Meklē darbinieku lomu pēc ID
    public async Task<EmployeeRoles?> GetEmployeeRoleById(int id)
    {
        return await _context.EmployeeRoles.FindAsync(id);
    }

    // Dzēš darbinieku lomu pēc ID
    public async Task<bool> DeleteEmployeeRole(int id)
    {
        var role = await _context.EmployeeRoles.FindAsync(id);
        if (role == null) return false;

        _context.EmployeeRoles.Remove(role);
        await _context.SaveChangesAsync();
        return true;
    }
}