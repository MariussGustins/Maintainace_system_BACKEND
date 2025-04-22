using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Maintainace_system_BACKEND.DTOs;

public class EmployeeIdentDto
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    [PasswordStrength]
    public string Password { get; set; } = string.Empty;
    public int EmployeeId { get; set; }
}
// Pielāgota validācijas atribūta klase
public class PasswordStrengthAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var password = value as string;
        if (string.IsNullOrWhiteSpace(password))
            return new ValidationResult("Parole ir obligāta");

        // Validācijas loģika
        var regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$");
        if (!regex.IsMatch(password))
        {
            return new ValidationResult("Parolei jābūt vismaz 8 simboliem, jāiekļauj lielie un mazie burti, cipari un simboli.");
        }

        return ValidationResult.Success!;
    }
}