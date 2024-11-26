namespace Maintainace_system_BACKEND.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public string Surname { get; set; }= string.Empty;
    public int Role_Id { get; set; }
    public string PictureUrl { get; set; } = string.Empty;
}