namespace Maintainace_system_BACKEND.Models;

public class Files
{
    public int Id { get; set; }
    public string FileName { get; set; }= string.Empty;
    public string FilePath { get; set; }= string.Empty;
    public int FileSize { get; set; }
    public string FileType { get; set; }= string.Empty;
    public string Date { get; set; }= string.Empty;
    public string Description { get; set; }= string.Empty;
    public bool IsActive { get; set; }
    public int EmployeeIdentId { get; set; }
}