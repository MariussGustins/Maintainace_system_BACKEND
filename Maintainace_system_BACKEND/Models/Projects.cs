namespace Maintainace_system_BACKEND.Models;

public class Projects
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public bool IsActive { get; set; }
}