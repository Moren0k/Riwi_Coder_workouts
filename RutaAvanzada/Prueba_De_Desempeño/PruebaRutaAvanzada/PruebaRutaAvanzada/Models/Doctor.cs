using System.ComponentModel.DataAnnotations;

namespace PruebaRutaAvanzada.Models;

public class Doctor : Person
{
    [Required, MaxLength(100)] public string Specialty { get; set; } = string.Empty;
}