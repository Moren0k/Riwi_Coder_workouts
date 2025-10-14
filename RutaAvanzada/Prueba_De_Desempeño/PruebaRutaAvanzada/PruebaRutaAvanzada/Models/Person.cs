using System.ComponentModel.DataAnnotations;

namespace PruebaRutaAvanzada.Models;

public abstract class Person
{
    [Key] public int Id { get; set; }

    [Required, MaxLength(100)] public string? FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)] public string? LastName { get; set; } = string.Empty;

    [MaxLength(100)] public string? SecondLastName { get; set; }

    [Required, MaxLength(20)] public string Document { get; set; } = string.Empty;

    [MaxLength(20)] public string? Phone { get; set; }

    [MaxLength(100)] public string? Email { get; set; }
}