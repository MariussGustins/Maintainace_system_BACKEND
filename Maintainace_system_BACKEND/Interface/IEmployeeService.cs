using Maintainace_system_BACKEND.DTOs;

namespace Maintainace_system_BACKEND.Interface;

public interface IEmployeeService
{
    /**
     * Iegūst visu darbinieku sarakstu.
     * @return Saraksts ar darbinieku DTO objektiem.
     */
    Task<IEnumerable<EmployeeDto>> GetEmployeeAsync();
    
    /**
     * Iegūst darbinieku sarakstu kopā ar to identifikācijas datiem.
     * @return Saraksts ar darbiniekiem un to identifikācijas informāciju.
     */
    Task<IEnumerable<EmployeeWithIdentDTO>> GetEmployeesWithIdentsAsync();
    
    /**
     * Izveido jaunu darbinieku.
     * @param employeeDto - Jaunā darbinieka dati DTO formātā.
     * @return Izveidotā darbinieka ID.
     */
    Task<int> CreateEmployeeAsync(EmployeeDto employeeDto);
    
    /**
     * Iegūst darbinieka datus pēc tā ID.
     * @param employeeId - Darbinieka unikālais identifikators.
     * @return Darbinieka DTO objekts vai null, ja darbinieks nav atrasts.
     */
    Task<EmployeeDto?> GetEmployeeByIdAsync(int employeeId);
    
    /**
     * Iegūst darbinieku kopā ar lomu, pamatojoties uz pieteikšanās datiem.
     * @param username - Lietotājvārds.
     * @param password - Parole.
     * @return Darbinieka DTO ar lomas informāciju vai null, ja lietotājs netika atrasts.
     */
    Task<EmployeeDto?> GetEmployeeWithRoleAsync(string username, string password);
}
