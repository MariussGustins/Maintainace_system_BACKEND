namespace Maintainace_system_BACKEND.Models;

public class Projects
{
    public int Id { get; set; }
    public string ProjectName { get; set; }= string.Empty;
    public string Description { get; set; }= string.Empty;
    public string StartDate { get; set; }= string.Empty;
    public string EndDate { get; set; }= string.Empty;
    public bool IsActive { get; set; }
}