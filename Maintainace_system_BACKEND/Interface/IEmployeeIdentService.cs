using Maintainace_system_BACKEND.DTOs;

namespace Maintainace_system_BACKEND.Interface;

public interface IEmployeeIdentService
{
    /**
     * Iegūst visus darbinieku identifikatorus.
     * @return Saraksts ar darbinieku identifikatoriem DTO formātā.
     */
    Task<IEnumerable<EmployeeIdentDto>> GetEmployeeIdentsAsync();
    
    /**
     * Izveido jaunu darbinieka identifikatoru.
     * @param employeeIdentDto - Jaunā darbinieka identifikatora dati DTO formātā.
     * @return Izveidotā darbinieka identifikatora ID.
     */
    Task<int> CreateEmployeeIdentAsync(EmployeeIdentDto employeeIdentDto);
}
