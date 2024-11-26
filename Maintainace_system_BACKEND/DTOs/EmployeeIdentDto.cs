namespace Maintainace_system_BACKEND.DTOs;

public class EmployeeIdentDto
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
}