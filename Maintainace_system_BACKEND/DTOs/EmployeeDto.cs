namespace Maintainace_system_BACKEND.DTOs;

public class EmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public string Surname { get; set; }= string.Empty;
    public int Role_Id { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;
}