using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos;

public record RegisterDto
{
    [Required(ErrorMessage = "User Name is required.")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Email is required.")]
    public string? EMail { get; init; }
    [Required(ErrorMessage = "Password is required.")]
    public string? Password { get; init; }
}
