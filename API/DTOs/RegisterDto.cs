using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
{
    [Required]
    public required string DisplayName { get; set; } = "";
    [Required]
    [EmailAddress]
    public required string Email { get; set; } = "";
    [Required]
    [MinLength(4)]
    public required string Password { get; set; } = "";

    [Required] public required string Gender { get; set; } = string.Empty;
    [Required] public required string City { get; set; } = string.Empty;
    [Required] public required string Country { get; set; } = string.Empty;
    [Required] public required DateOnly DateOfBirth { get; set; }
}
