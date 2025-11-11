using System.ComponentModel.DataAnnotations;

namespace System.Domain.Models;

public class Customer
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Required] [MaxLength(250)] public string Email { get; set; } = string.Empty;
}