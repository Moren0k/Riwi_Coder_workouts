using System.ComponentModel.DataAnnotations;

namespace System.Application.DTOs;

public class RegisterRequest
{
    [Required, MinLength(3), MaxLength(100)]
    public string Username { get; set; } = null!;

    [Required, EmailAddress] public string Email { get; set; } = null!;

    [Required, MinLength(6)] public string Password { get; set; } = null!;

    public string? Role { get; set; }
}