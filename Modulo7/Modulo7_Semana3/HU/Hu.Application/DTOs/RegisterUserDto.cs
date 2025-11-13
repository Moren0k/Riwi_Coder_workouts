using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Hu.Domain.Models;

namespace Hu.Application.DTOs;

public class RegisterUserDto
{
    [Required, MaxLength(100)] public string Username { get; set; } = string.Empty;
    [Required, EmailAddress] public string Email { get; set; } = string.Empty;
    [Required, MinLength(5)] public string Password { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.User;
}