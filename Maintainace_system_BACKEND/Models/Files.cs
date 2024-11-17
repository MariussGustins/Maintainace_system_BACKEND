namespace Maintainace_system_BACKEND.Models;

public class Files
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public int FileSize { get; set; }
    public string FileType { get; set; }
    public string Date { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public int EmployeeIdentId { get; set; }
}