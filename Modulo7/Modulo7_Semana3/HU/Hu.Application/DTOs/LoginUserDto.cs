using System.ComponentModel.DataAnnotations;
using Hu.Domain.Models;

namespace Hu.Application.DTOs;

public class LoginUserDto
{
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required, MinLength(5)] public string Password { get; set; } = string.Empty;
}