using System.ComponentModel.DataAnnotations.Schema;

namespace Maintainace_system_BACKEND.Models;
[Table("Employees")]
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Role_Id { get; set; } // Atsauce uz lomu ID
    public string PictureUrl { get; set; } = string.Empty;

    // Navigācijas īpašības
    public EmployeeRoles Role { get; set; } = null!;
    public ICollection<EmployeeIdent> EmployeeIdents { get; set; } = new List<EmployeeIdent>();
}